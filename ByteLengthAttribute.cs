using System.ComponentModel.DataAnnotations;
using System.Text;

public class ByteLengthAttribute : ValidationAttribute
{
    private readonly int _maxBytes;
    public ByteLengthAttribute(int maxBytes)
    {
        _maxBytes = maxBytes;
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        string strValue = value.ToString();
        int byteCount = Encoding.UTF8.GetByteCount(strValue);

        if (byteCount > _maxBytes)
        {
            // **使用 Model 屬性上的 ErrorMessage，如果沒有則使用預設值**
            string errorMessage = string.IsNullOrEmpty(ErrorMessage)
                ? $"字數過長，請刪減。"
                : ErrorMessage;

            return new ValidationResult(errorMessage);
        }

        return ValidationResult.Success;
    }

}
