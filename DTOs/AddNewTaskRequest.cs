using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_09.DTOs
{
    public class AddNewTaskRequest
    {
        [Required] 
        public string Name { get; set; }
            

        public DateTime DeadLine { get; set; }
      

    }
}
