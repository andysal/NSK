using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Nsk.Domain.Model
{
    public class ContactInfo
    {
        [StringLengthValidator(30)]
        public string ContactName { get; set; }

        [StringLengthValidator(30)]
        public string ContactTitle { get; set; }

        public override string ToString()
        {
            return ContactName + ", " + ContactTitle;
        }
    }
}
