using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.IO;

namespace TodoListApp
{
    public class TodoViewModel
    {
        public ObservableCollection<TodoItem> TodoItems { get; set; }
        public List<TodoItem> TodoItemsList { get; set; }
        public TodoViewModel()
        {
            TodoItems = new ObservableCollection<TodoItem>();
            TodoItemsList = (List<TodoItem>)Database.GetItems();
            foreach (var item in TodoItemsList)
                TodoItems.Add(item);
        }


        public const string DATABASE_NAME = "todo.db";
        public static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(
                        Path.Combine(
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        
        public ICommand AddTodoCommand => new Command(AddTodoItem);
        public string NewTodoInputValue { get; set; }
        public void AddTodoItem()
        {
            var newItem = new TodoItem
            {
                TodoText = NewTodoInputValue,
                IsComplete = false
            };
            Database.SaveItem(newItem);
            TodoItems.Add(newItem);
        }

        public ICommand RemoveTodoCommand => new Command(DeleteTodoItem);
        public void DeleteTodoItem(object o)
        {
            TodoItem todoItemBeingRemoved = o as TodoItem;
            Database.DeleteItem(todoItemBeingRemoved.Id);
            TodoItems.Remove(todoItemBeingRemoved);
        }
    }
}
