using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dnc.API.Models
{
    public class UserInputVm
    {
        [Required,MaxLength(10)]
        public string UName { get; set; }
        [Required,MinLength(6)]
        public string Pwd { get; set; }
    }
}
