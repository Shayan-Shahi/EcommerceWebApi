using Ecommerce.Common.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels.Application;

public abstract class GoogleReCaptchaModel
{
    [Required]
    [GoogleReCaptchaValidation]
    [BindProperty(Name = "g-recaptcha-response")]
    public string GoogleReCaptchaResponse { get; set; }
}
