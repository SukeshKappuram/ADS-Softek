using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshoppingBL
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


    }

        public class CategoryBL
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            public IEnumerable<Category> Categorys
            {
                get
                {
                    List<Category> Categorys = new List<Category>();
                    using (SqlConnection conobj = new SqlConnection(conString))
                    {
                        SqlCommand cmd = new SqlCommand("CategorySelect", conobj);
                        conobj.Open();
                        SqlDataReader robj = cmd.ExecuteReader();
                        while (robj.Read())
                        {
                            Category c = new Category();
                            c.Id = Convert.ToInt32(robj["Id"].ToString());
                            c.Name = robj["Name"].ToString();
                            c.Description = robj["Description"].ToString();
                            Categorys.Add(c);
                        }
                    }
                    return Categorys;
                }
            }

            public int InsertCategory(Category Category)
            {
                using (SqlConnection conobj = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand("insrtCategory", conobj);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@name", Category.Name));
                    cmd.Parameters.Add(new SqlParameter("@description", Category.Description));
                    conobj.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }

            }

            public int UpdateCategory(Category Category)
            {
                using (SqlConnection conobj = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand("updtCategory", conobj);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Category.Id));
                    cmd.Parameters.Add(new SqlParameter("@name", Category.Name));
                    cmd.Parameters.Add(new SqlParameter("@description", Category.Description));
                    conobj.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }

            }

            public int DeleteCategory(int CategoryId)
            {
                using (SqlConnection conobj = new SqlConnection(conString))
                {
                    SqlCommand cmd = new SqlCommand("dltCategory", conobj);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", CategoryId));
                    conobj.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
        }
    }

