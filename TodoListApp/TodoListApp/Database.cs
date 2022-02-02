using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Collections.ObjectModel;

namespace TodoListApp
{
    public class Database
    {
        SQLiteConnection database;
        public Database(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<TodoItem>();
        }
        public IEnumerable<TodoItem> GetItems()
        {
            return database.Table<TodoItem>().ToList();
        }
        public TodoItem GetItem(int id)
        {
            return database.Get<TodoItem>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<TodoItem>(id);
        }
        public int SaveItem(TodoItem item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

    }
}
