using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MvcMovie.Models
{
    //
    public class Banner 
    {
        public int Id { get; set; }
        public int bannerIndex { get; set; }
        public int bannerState {get; set;}
        public string bannerContentUp {get; set;}
        public string bannerContentDown {get; set;}

        [Display(Name = "Profile Picture")]
        [NotMapped]
        public IFormFile ProfileImage {get; set;}
        public string ProfilePicture {get; set;}
    }
}