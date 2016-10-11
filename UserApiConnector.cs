using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace profiwowdektop
{
    public class UserApiConnector : AbstractApiConnector
    {
        private string UserRegister(string url, CUserRegister userregister)
        {
            string serializowanyuser = JsonConvert.SerializeObject(userregister);

            return this.GetRespPost(url, serializowanyuser);
        }

        public string Login(string url, CUser user)
        {
            string serializowanyuser = JsonConvert.SerializeObject(user);

           return this.GetRespPost(url, serializowanyuser);
            
        }
    }
}
