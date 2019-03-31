using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo.Models;

namespace Todo.Repository
{
    public class TodoRepository
    {
        public static List<TodoItem> _items;

        static TodoRepository()
        {
            _items = new List<TodoItem>();
            InitializeTestData();
        }

        static void InitializeTestData()
        {
            _items.Add(new TodoItem(Guid.NewGuid(), "Knowledge share", DateTime.Parse("2019-04-03"), string.Empty));
            _items.Add(new TodoItem(Guid.NewGuid(), "Scrum meeting", DateTime.Parse("2019-04-04"), "All team members are required."));
            _items.Add(new TodoItem(Guid.NewGuid(), "QA server deployment", DateTime.Parse("2019-04-08"), "Need to notify Siby."));
        }

        public IEnumerable<TodoItem> List(DateTime from, DateTime to)
        {
            return _items.Where(x => x.DueTime >= from && x.DueTime <= to).ToList();
        }

        public TodoItem Add(TodoItem item)
        {
            item.Id = Guid.NewGuid();
            _items.Add(item);

            return item;
        }

        public TodoItem GetDetail(Guid id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public void Update(TodoItem item)
        {
            _items.Remove(_items.Find((x => x.Id == item.Id)));
            _items.Add(item);
        }

        public void Delete(Guid id)
        {
            _items.Remove(_items.Find((x => x.Id == id)));
        }
    }
}