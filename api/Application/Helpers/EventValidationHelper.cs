using System.ComponentModel.DataAnnotations;

public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null)
            return true; 

        if (value is DateTime date)
        {
            return date.Date >= DateTime.Now.Date;
        }

        return false; 
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} must be a future date.";
    }
}
