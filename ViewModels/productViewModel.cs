using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MvcWeb.ViewModels
{
    public class productViewModel : EditImageViewModel
    {
        [Key]
        public int productId { get; set; }
        [Required(ErrorMessage = "Please add the index number of this product")]
        public int productIndex { get; set; } //產品編號
        [Required(ErrorMessage = "Please add the amount of this product")]
        public int productNumber{get; set;}//產品數量
        public float productPrice{get; set;}//產品價錢
        [Required(ErrorMessage = "Please add the this product name")]
        public string productName {get; set;}//產品名稱
        public string productDescription {get; set;}//產品描述
        [Required(ErrorMessage = "Please add the unit of this product")]
        public string productUnit {get; set;}//產品單位
        public string productPosition{get; set;}//產品位置
        public string productPs{get; set;}//產品備註

        [Display(Name = "Profile Picture")]
        public IFormFile productImage {get; set;}
        public string productPicture {get; set;}
    }
}