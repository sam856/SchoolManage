using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Data.CustomArttibute
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            DateTime dateValue;

            if (DateTime.TryParse(value.ToString(), out dateValue))
            {
                return dateValue.Date >= DateTime.Now.Date;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} cannot be in the past.";
        }
    }



}
