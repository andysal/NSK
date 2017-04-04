using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Nsk.Domain.Model
{
    public class PostalAddress
    {
        [StringLengthValidator(60)]
        public string Address { get; set; }

        [StringLengthValidator(15)]
        public string City { get; set; }

        [StringLengthValidator(15)]
        public string Region { get; set; }

        [StringLengthValidator(10)]
        public string PostalCode { get; set; }

        [StringLengthValidator(15)]
        public string Country { get; set; }
    }
}
