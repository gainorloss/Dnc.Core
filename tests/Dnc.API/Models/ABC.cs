using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.API.Models
{
    public class ABC
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Price { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreateTime { get; set; }
        public State State { get; set; }
    }
}
