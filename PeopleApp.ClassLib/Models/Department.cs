using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PeopleApp.ClassLib.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Person>? People { get; set; }
    }
}
