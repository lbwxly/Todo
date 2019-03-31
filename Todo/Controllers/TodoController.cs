using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Swashbuckle.Swagger.Annotations;
using Todo.Infrastructure;
using Todo.Infrastructure.Auth;
using Todo.Models;
using Todo.Repository;

namespace Todo.Controllers
{
    [RoutePrefix("todos")]
    [BasicAuthorize]
    public class TodoController : ApiController
    {
        private TodoRepository _todoRepository = new TodoRepository();

        /// <summary>
        /// Lists all todo items.
        /// </summary>
        /// <returns></returns>
        [Route]
        [HttpGet]
        public IEnumerable<TodoItem> List([ModelBinder(BinderType = typeof(DateBinder))]DateTime? date = null)
        {
            if (date == null)
            {
                date = DateTime.Today;
            }

            return _todoRepository.List(date.Value, date.Value.AddDays(1));
        }

        //[Route]
        //[HttpGet]
        //public IEnumerable<TodoItem> List(bool byYear, int year = 2019)
        //{
        //    return _todoRepository.List(DateTime.MinValue, DateTime.MaxValue);
        //}

        ///// <summary>
        ///// Lists todo items by date.
        ///// </summary>
        ///// <param name="date">target date</param>
        ///// <returns>todo item list match the date</returns>
        //[Route]
        //[HttpGet]
        //[SwaggerOperation("ListByDueTime")]
        //public IEnumerable<TodoItem> List(DateTime? date)
        //{
        //    DateTime targetDate = date ?? DateTime.Today;
        //    return _todoRepository.List(targetDate, targetDate);
        //}


        /// <summary>
        /// Get the todo item detail with Id.
        /// </summary>
        /// <param name="id">todo item id.</param>
        /// <returns>the todo item detail.</returns>
        [Route("{id:guid}")]
        [GuidValidation(ParameterName = "id")]
        [HttpGet]
        public TodoItem Get([FromUri(Name = "id")]Guid itemId)
        {
            return _todoRepository.GetDetail(itemId);
        }

        /// <summary>
        /// Create a todo item.
        /// </summary>
        /// <param name="item">the new todo item.</param>
        /// <returns>new created item.</returns>
        [Route]
        [HttpPost]
        public TodoItem Create([FromBody]TodoItem item)
        {
            return _todoRepository.Add(item);
        }

        /// <summary>
        /// Updates a todo item.
        /// </summary>
        /// <param name="item">the updated item.</param>
        [Route("{id:guid}")]
        [HttpPut]
        public void Update([FromBody]TodoItem item)
        {
            _todoRepository.Update(item);
        }

        /// <summary>
        /// Delete a todo item with id.
        /// </summary>
        /// <param name="id">the id of deleting todo item.</param>
        [Route("{id:guid}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            _todoRepository.Delete(id);
        }
    }
}