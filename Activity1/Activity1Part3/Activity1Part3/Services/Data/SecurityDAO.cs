using Activity1Part3.Models;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Activity1Part3.Services.Data
{
    public class SecurityDAO
    {
        public bool FindByUser(UserModel user)
        {
            bool result = false;
            int count = 0;
            using (SqlConnection db = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Test;Trusted_Connection=Yes"))
            {
                db.Open();
                string sql = "SELECT * FROM Users WHERE USERNAME = @username and PASSWORD = @password";
                using (SqlCommand command = new SqlCommand(sql, db))
                {
                    command.Parameters.Add("@username", System.Data.SqlDbType.VarChar);
                    command.Parameters.Add("@password", System.Data.SqlDbType.VarChar);
                    command.Parameters["@username"].Value = user.Username;
                    command.Parameters["@password"].Value = user.Password;
                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        Debug.WriteLine("Here, username => '" + user.Username + "' password => '" + user.Password + "'");
                        while (reader.Read())
                        {
                            Debug.WriteLine("DB username => '" + reader["USERNAME"] + "' password => '" + reader["PASSWORD"] + "'");
                            if (reader["USERNAME"].Equals(user.Username) && reader["PASSWORD"].Equals(user.Password))
                            {
                                count += 1;
                            }
                        }
                        if (count > 0)
                        {
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        // whoops
                    }
                }
                db.Close();
            }
            Debug.WriteLine("Count is => " + count);
            return result;
        }
    }
}