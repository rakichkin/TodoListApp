using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TodoListApp
{
    [Table("TodoItems")]
    public class TodoItem
    {
        [AutoIncrement, PrimaryKey, Column("_id")]
        public int Id { get; set; }
        public string TodoText { get; set; }
        public bool IsComplete { get; set; }
    }
}
