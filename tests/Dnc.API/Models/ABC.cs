using Dnc.Seedwork;
using System;

namespace Dnc.API.Models
{
    public class ABC
        :Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Price { get; set; }
        public int Age { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreateTime { get; set; }
        public State State { get; set; }
    }
}
