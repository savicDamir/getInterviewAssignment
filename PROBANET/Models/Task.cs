using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PROBANET.Models
{
    public partial class Task
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please chose status")] 
        [Display( Name="Task status")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Please enter progress")] 
        [Display( Name="Progress")]
        [Range(0,100,ErrorMessage = "Please enter range between 0% and 100% ")]
        public int Progress { get; set; }
        
        [Required(ErrorMessage = "Please enter date")]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
        [Required(ErrorMessage = "Please enter Description")] 
        [Display( Name="Description")]
        public string Description { get; set; }
        
        [Display( Name="Developer")]
        public int? Assigned { get; set; }
        [Required(ErrorMessage = "Please chose project")] 
        [Display( Name="Project")]
        public int ProId { get; set; }

        public virtual User AssignedNavigation { get; set; }
        public virtual Project Pro { get; set; }
    }
}
