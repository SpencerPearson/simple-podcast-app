using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimplePodcastApp.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage ="*Please provide a name.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="*Please provide a valid email address.")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText ="[No Subject]")]
        public string Subject { get; set; }

        [UIHint("MultilineText")]
        [Required(ErrorMessage ="*Please provide a message.")]
        public string Message { get; set; }
    }
}