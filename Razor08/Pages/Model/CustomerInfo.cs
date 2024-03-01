using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Razor08.Binders;
using Razor08.Validation;
namespace Razor08.Pages.Model
{
    public class CustomerInfo
    {

        [Display(Name ="Tên khách hàng")]
        [Required(ErrorMessage ="Phải nhập {0}")]
        [StringLength(20, MinimumLength =3 , ErrorMessage ="{0} phải dài từ {2} đến {1} ký tự ")]
        [ModelBinder(BinderType =typeof(UserNameBinding))]
        public string CustomerName { get; set; }

        [Display(Name = "Địa chỉ Email")]
        [EmailAddress(ErrorMessage ="{0} không phù hợp")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string CustomerEmail { get; set; }
        [DisplayName("Năm sinh")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Range(1970 , 2010, ErrorMessage ="Bạn nhập sai {0}" )]
        [Sochan]
        public int? YearOfBirth { get; set; }
    }
}
