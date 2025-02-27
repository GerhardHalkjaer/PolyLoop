using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PackagingRepo
    {
        public List<Packaging> GetAll()
        {
            List<Packaging> packagings = new List<Packaging>();
            string query = "SELECT * FROM Packagings";

            using (SqlConnection con = new SqlConnection(ConnectionString.ConString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();

                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Packaging packaging = new Packaging();

                        packaging.Id = (int)dataReader["Id"];
                        packaging.Name = dataReader["Name"].ToString();
                        packaging.IconPath = dataReader["IconPath"].ToString();
                        packaging.PackagingWeight = (int)dataReader["PackagingWeight"];

                        packagings.Add(packaging);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }
            }

            return packagings;
        }

        public List<Packaging> GetById(int id)
        {
            //TODO
            return null;
        }

        public void SaveNew(Packaging type)
        {
            //TODO
        }
    }
}
