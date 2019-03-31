using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Todo.Models
{
    [DataContract]
    public class TodoItem
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "dueTime")]
        public DateTime DueTime { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }
    }
}