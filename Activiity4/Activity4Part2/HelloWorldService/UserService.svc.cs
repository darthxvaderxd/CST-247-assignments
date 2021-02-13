using Activity1Part3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HelloWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private List<UserModel> users;
        public UserService()
        {
            users = new List<UserModel>();
            UserModel user1 = new UserModel();
            user1.Password = "testPassword@1";
            user1.Username = "bob";

            UserModel user2 = new UserModel();
            user2.Password = "12345";
            user2.Username = "bill";

            users.Add(user1);
            users.Add(user2);
        }

        DTO IUserService.GetAllUsers()
        {
            DTO response = new DTO();
            
            response.ErrorMsg = "OK";
            response.ErrorCode = 0;
            response.Data = users;

            return response;
        }

        DTO IUserService.GetUser(string id)
        {
            int index = -1;
            DTO response = new DTO();

            try
            {
                index = int.Parse(id);
                UserModel user = users.ElementAt(index);

                response.ErrorMsg = "OK";
                response.ErrorCode = 0;
                response.Data = new List<UserModel>();
                response.Data.Add(user);
            }
            catch (Exception e)
            {
                // swallow error
                response.ErrorMsg = "User Does Not Exist";
                response.ErrorCode = -1;
            }

            return response;
        }
    }
}
