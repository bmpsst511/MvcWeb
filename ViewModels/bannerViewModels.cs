using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MvcWeb.ViewModels
{
    public class bannerViewModel : EditImageViewModel
    {
        //透過View Model能夠更新已上傳過的圖片
        [Key]
        public int Id { get; set; }
        public int bannerIndex { get; set; }

        public int bannerState { get; set; }

        public string bannerContentUp { get; set; }

        public string bannerContentDown { get; set; }

        //[Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }

        public string ProfilePicture { get; set; }

    }
}