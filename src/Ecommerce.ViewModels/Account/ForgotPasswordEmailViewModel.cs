using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModels.Account
{
    public class ForgotPasswordEmailViewModel
    {
        public string UserName { get; set; }

        public string ResetPasswordCode { get; set; }
    }

}
