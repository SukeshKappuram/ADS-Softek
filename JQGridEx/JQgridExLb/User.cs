using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQgridExLb
{
    public class User
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string mailId { get; set; }
       public string phoneNumber { get; set; }
        public DateTime dob { get; set; }
    }

    public class UserBL {
        string conString = ConfigurationManager.ConnectionStrings["EShoppingContext"].ConnectionString;
        public IEnumerable<User> Users {
            get {
                List<User> Users = new List<User>();
                using (SqlConnection conobj = new SqlConnection(conString)) {
                    SqlCommand cmd = new SqlCommand("userSelect", conobj);
                    conobj.Open();
                    SqlDataReader robj = cmd.ExecuteReader();
                    while (robj.Read()) {
                        User u = new User();
                        u.Id = Convert.ToInt32(robj["Id"].ToString());
                        u.firstName = robj["firstName"].ToString();
                        u.middleName = robj["middleName"].ToString();
                        u.lastName = robj["lastName"].ToString();
                        u.mailId = robj["mailId"].ToString();
                        u.phoneNumber = robj["phoneNumber"].ToString();
                        u.dob = Convert.ToDateTime(robj["dob"]);
                        Users.Add(u);
                    }
                }
                return Users;
            }
        }

        public int InsertUser(User user)
        {
            using (SqlConnection conobj = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("insrtUser", conobj);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@firstName", user.firstName));
                cmd.Parameters.Add(new SqlParameter("@middleName", user.middleName));
                cmd.Parameters.Add(new SqlParameter("@lastName", user.lastName));
                cmd.Parameters.Add(new SqlParameter("@mailId", user.mailId));
                cmd.Parameters.Add(new SqlParameter("@phoneNumber", user.phoneNumber));
                cmd.Parameters.Add(new SqlParameter("@dob", user.dob));
                conobj.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }

        }

        public int UpdateUser(User user)
        {
            using (SqlConnection conobj = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("updtUser", conobj);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@userId", user.Id));
                cmd.Parameters.Add(new SqlParameter("@firstName", user.firstName));
                cmd.Parameters.Add(new SqlParameter("@middleName", user.middleName));
                cmd.Parameters.Add(new SqlParameter("@lastName", user.lastName));
                cmd.Parameters.Add(new SqlParameter("@mailId", user.mailId));
                cmd.Parameters.Add(new SqlParameter("@phoneNumber", user.phoneNumber));
                cmd.Parameters.Add(new SqlParameter("@dob", user.dob));
                conobj.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }

        }

        public int DeleteUser(int userId)
        {
            using (SqlConnection conobj = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("dltUser", conobj);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                conobj.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }

        }

        
    }
}
