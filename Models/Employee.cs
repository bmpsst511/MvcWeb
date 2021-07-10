using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MvcWeb.Models
{
    public class Employee 
    {
        [Key]
        public int employeeId { get; set; }

        [Required(ErrorMessage = "Please add the index number of employee")]
        public int employeeIndex { get; set; } //成員編號

        [Required(ErrorMessage = "Please add the employee name")]
        public string employeeName {get; set;}//成員名稱
        public string employeeIntro {get; set;}//成員簡介
        public string employeeDegree {get; set;}//成員學歷
        public DateTime employeeBirth {get; set;}//成員生日

        [Display(Name = "Profile Picture")]
        [NotMapped]
        public IFormFile employeeImage {get; set;}
        public string employeePicture {get; set;}
    }
}