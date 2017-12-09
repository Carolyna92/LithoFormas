using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace LithoFormas
{
   public  interface LithoFormas_SQLAzure
    {
        Task<MobileServiceUser> Authenticate();

        Task<bool> LogoutAsync();
    }

}
