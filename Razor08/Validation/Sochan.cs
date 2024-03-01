using System.ComponentModel.DataAnnotations;

namespace Razor08.Validation
{
    public class Sochan: ValidationAttribute
    {
        public Sochan() => ErrorMessage = "{0} phải là số chẵn";
        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            int i = int.Parse(value.ToString());
            return i % 2 == 0;
        }
    }
}
