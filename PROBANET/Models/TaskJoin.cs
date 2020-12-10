using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PROBANET.Models
{
    public partial class TaskJoin
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public int? Assigned { get; set; }
        public int ProId { get; set; }

        public string ProName { get; set; }
        public string? AssignedName {get; set;}
    }
}
