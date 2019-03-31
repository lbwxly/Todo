using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Todo.Models;

namespace Todo.Controllers
{
    [RoutePrefix("todos")]
    public class TodoController : ApiController
    {
        [Route]
        [HttpGet]
        public List<TodoItem> List()
        {
            return new List<TodoItem>() { new TodoItem() { Name = "Knowledge Share", DueTime = DateTime.Now, Comment = "HongKong meeting room" } };
        }

        [Route]
        [HttpGet]
        public List<TodoItem> List(DateTime date)
        {
            return new List<TodoItem>() { new TodoItem() { Name = "Knowledge Share", DueTime = DateTime.Now, Comment = "HongKong meeting room" } };
        }

        [Route("{id}")]
        [HttpGet]
        public TodoItem Get(Guid ids)
        {
            return null;
        }

        [Route]
        [HttpPost]
        public void Create([FromBody]TodoItem item)
        {
        }

        [Route]
        [HttpPut]
        public void Update([FromBody]TodoItem item)
        {
        }

        [Route("{id}")]
        [HttpPost]
        public void Delete(Guid id)
        {
        }
    }
}