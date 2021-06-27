using System;
using System.ComponentModel.DataAnnotations;

namespace MvcWeb.Models
{
    public class SubBoard
    {
        [Key]
        public int Sub_Id { get; set; }

        [Required(ErrorMessage = "Please add the information")]
        public string Sub_Name { get; set; }

        [Required(ErrorMessage = "Please add the information")]
        public string Sub_Link { get; set; }

        [Required(ErrorMessage = "Please add the information")]
        public int Sub_Index { get; set; }
    }
}
