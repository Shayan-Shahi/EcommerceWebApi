using Ecommerce.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ecommerce.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$", ErrorMessage = AttributesErrorMessages.RegularExpressionMessage)]
        [MaxLength(100, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
        public string Email { get; set; }
    }

}
