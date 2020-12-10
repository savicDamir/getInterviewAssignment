using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PROBANET.Models
{
    public partial class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter  name")] 
        [Display( Name="Project Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter code")] 
        [Display( Name="Code")]
        public string Code { get; set; }
    
        [Display( Name="Please chose manager")]
        public int? ManId { get; set; }
        
        public virtual ICollection<Task> Tasks { get; set; }

        public virtual User Man { get; set; }
    }
}
