namespace TodoList.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class TodoItem
    {
        public int TodoItemId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime LastChanged { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}