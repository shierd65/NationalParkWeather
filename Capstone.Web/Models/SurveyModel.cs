using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public int SurveyID { get; set; }

        [Required]
        public string ParkCode { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required]
        public string ActivityLevel { get; set; }


    }
}