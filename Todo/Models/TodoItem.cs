using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Todo.Models
{
    /// <summary>
    /// The todo item.
    /// </summary>
    [DataContract]
    public class TodoItem
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public TodoItem() { }

        /// <summary>
        /// Constructor with parameter.
        /// </summary>
        /// <param name="id">The id of the item.</param>
        /// <param name="name">The name of the item.</param>
        /// <param name="dueTime">due time.</param>
        /// <param name="comment">the comment of the todo item.</param>
        public TodoItem(Guid id,string name, DateTime dueTime, string comment)
        {
            Id = id;
            Name = name;
            DueTime = dueTime;
            Comment = comment;
        }

        /// <summary>
        /// The id of the item.
        /// </summary>
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the todo item.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The due time of the todo item.
        /// </summary>
        [DataMember(Name = "dueTime")]
        public DateTime DueTime { get; set; }

        /// <summary>
        /// The comment of the todo item.
        /// </summary>
        [DataMember(Name = "comment")]
        public string Comment { get; set; }
    }
}