using Newtonsoft.Json;

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
