﻿using PeopleApp.ClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PeopleApp.ClassLib.Models
{
    public class Location
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [JsonIgnore]
        public ICollection<Person>? People { get; set; }
    }
}


