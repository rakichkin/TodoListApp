using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TodoListApp
{
    public class TodoViewModel
    {
        public ObservableCollection<TodoItem> TodoItems { get; set; }
        public TodoViewModel()
        {
            TodoItems = new ObservableCollection<TodoItem>();

            TodoItems.Add(new TodoItem("abc", false));
            TodoItems.Add(new TodoItem("abc", true));
            TodoItems.Add(new TodoItem("abc", false));
        }

        public ICommand AddTodoCommand => new Command(AddTodoItem);
        public string NewTodoInputValue { get; set; }
        public void AddTodoItem()
        {
            TodoItems.Add(new TodoItem(NewTodoInputValue, false));
        }

        public ICommand RemoveTodoCommand => new Command(DeleteTodoItem);
        public void DeleteTodoItem(object o)
        {
            TodoItem todoItemBeingRemoved = o as TodoItem;
            TodoItems.Remove(todoItemBeingRemoved);
        }
    }
}
