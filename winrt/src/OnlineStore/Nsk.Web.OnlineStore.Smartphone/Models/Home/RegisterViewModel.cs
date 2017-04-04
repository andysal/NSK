using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Nsk.Web.Mvc;

namespace Nsk.Web.OnlineStore.Smartphone.Models.Home
{
    public class RegisterViewModel : HtmlPageViewModel, IValidatableObject
    {
        [Display(Name = "FirstName", ResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register))]
        [Required(ErrorMessageResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register), ErrorMessageResourceName = "FirstNameRequired")]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register))]
        [Required(ErrorMessageResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register), ErrorMessageResourceName = "LastNameRequired")]
        public string LastName { get; set; }

        [Display(Name = "BirthDate", ResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register))]
        [Required(ErrorMessageResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register), ErrorMessageResourceName = "BirthDateRequired")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "EmailAddress", ResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register))]
        [RegularExpression(@"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "The given address does not appear to be valid")]
        [Required(ErrorMessageResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register), ErrorMessageResourceName = "EmailAddressRequired")]
        public string EmailAddress { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register))]
        [Required(ErrorMessageResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register), ErrorMessageResourceName = "UserNameRequired")]
        [Remote("ValidateUniqueUserName", "Home", ErrorMessageResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register), ErrorMessageResourceName = "UserNameAlreadyExists")]
        public string UserName { get; set; }
       
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register))]
        [Required(ErrorMessageResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register), ErrorMessageResourceName = "PasswordRequired")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessageResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register), ErrorMessageResourceName = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register))]
        [Required(ErrorMessageResourceType = typeof(Nsk.Web.OnlineStore.Smartphone.Resources.Home.Register), ErrorMessageResourceName = "ConfirmPasswordRequired")]
        public string ConfirmPassword { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            Contract.Requires<ArgumentNullException>(validationContext != null, "validationContext");

            IList<ValidationResult> results = new List<ValidationResult>();
            if (this.Password.Length < 8)
            {
                results.Add(new ValidationResult("Password should be at least of length 8", new string[] { "Password" }));
            }
            if (this.BirthDate >= DateTime.Now)
            {
                results.Add(new ValidationResult("Birth date cannot be a future one", new string[] { "BirthDate" }));
            }
            return results;
        }
    }
}