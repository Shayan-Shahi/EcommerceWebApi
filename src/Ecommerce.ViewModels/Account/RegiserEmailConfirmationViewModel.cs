using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels.Account
{
    public class RegisterEmailConfirmationViewModel
    {
        public string CreatedDateTime { get; set; }
        public string UserName { get; set; }
        public string ActivationCode { get; set; }
    }
}
