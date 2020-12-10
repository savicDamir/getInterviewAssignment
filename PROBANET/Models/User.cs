using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

#nullable disable

namespace PROBANET.Models
{
    public partial class User
    {
        public User()
        {
            Projects = new HashSet<Project>();
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter username")]  
        [Display( Name="Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter password")]  
        [Display( Name="Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter first name")] 
        [Display( Name="First Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter surname")] 
        [Display( Name="Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter email")] 
        [EmailAddress (ErrorMessage = "Please enter valid email")]
        [Display( Name="Email")]
        public string Email { get; set; }
        [Display( Name="Role")]
        public string Role { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
