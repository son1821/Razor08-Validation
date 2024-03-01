using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor08.Pages.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Razor08.Validation;
namespace Razor08.Pages
{
    public class ContactModel : PageModel
    {
        public readonly IWebHostEnvironment environment;
        public ContactModel(IWebHostEnvironment _enviroment) { 
        
        environment = _enviroment;
        }   
        [BindProperty(SupportsGet =true)]
        public CustomerInfo customerInfo { set; get; }

        [BindProperty(SupportsGet =true)]
        [DataType(DataType.Upload)]
        //[Required(ErrorMessage ="Phải Upload file")]
        [CheckFileExtensions(Extensions ="jpg,png")]
        [DisplayName("File upload")]
        public IFormFile FileUploader { get; set; }


        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Phải Upload file")]
        [DisplayName("File upload nhieu")]
        public IFormFile[] FileUploaders {  get; set; }
        public void OnGet()
        {
        }
        public string thongbao {  get; set; }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                thongbao = "Dữ liệu gửi đến phù hợp";

                if (FileUploader != null)
                {
                    var filePath = Path.Combine(environment.WebRootPath,"uploads",FileUploader.FileName);
                    using var filestream = new FileStream(filePath, FileMode.Create);
                    FileUploader.CopyTo(filestream);
                }
                foreach(var file in FileUploaders)
                {
                    var filePath = Path.Combine(environment.WebRootPath, "uploads", file.FileName);
                    using var filestream = new FileStream(filePath, FileMode.Create);
                    file.CopyTo(filestream);
                }

            }
            else
            {
                thongbao = "Dữ liệu gửi đến không phù hợp";
            }
        }
    }
}
