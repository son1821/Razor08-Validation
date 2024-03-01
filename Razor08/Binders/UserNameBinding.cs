using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Razor08.Binders
{
    public class UserNameBinding : IModelBinder
    {
        /*
        -Chuyen chu thuong thanh chu in HOA
        -Tên không được chứa xxx
        - Cắt khoảng trắng ở đầu và cuối
         
         */
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
                

            string modelName = bindingContext.ModelName;

            //Đọc giá trị gửi đến
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            //Thiết lập cho ModelSate giá trị binding
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
            //Đọc giá trị đầu tiên
            string value = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }
            
            //Binding
            var s = value.ToUpper();
            if (s.Contains("XXX"))
            {
                
                bindingContext.ModelState.TryAddModelError(modelName, "Lỗi chứa xxx");
                return Task.CompletedTask;

            }
            
            
            bindingContext.Result = ModelBindingResult.Success(s.Trim());
            return Task.CompletedTask;
        }
    }
}
