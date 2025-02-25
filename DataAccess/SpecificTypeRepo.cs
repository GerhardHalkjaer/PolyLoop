using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SpecificTypeRepo
    {

        public List<SpecificType> GetAll()
        {
            List<SpecificType> specificTypes = new List<SpecificType>();
            string query = "SELECT SpecificTypes.*, MaterialTypes.Id AS MatId, MaterialTypes.[Name] AS MatName, MaterialTypes.IconPath AS MatIconPath" +
                           " FROM MaterialTypes INNER JOIN SpecificTypes ON MaterialTypes.Id = SpecificTypes.MaterialTypeId";
            SqlConnection con = new SqlConnection(ConnectionString.ConString);
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();

                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    SpecificType specType = new SpecificType();
                    MaterialType matType = new MaterialType();

                    matType.Id = (int)dataReader["MatId"];
                    matType.Name = dataReader["MatName"].ToString();
                    matType.IconPath = dataReader["MatIconPath"].ToString();

                    specType.MatType = matType;
                    specType.Id = (int)dataReader["Id"];
                    specType.Name = dataReader["Name"].ToString();
                    specType.IconPath = dataReader["IconPath"].ToString();

                    specificTypes.Add(specType);
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


            return specificTypes;
        }

        public List<SpecificType> GetById(int id)
        {

            return null;
        }

        public void SaveNew(SpecificType type)
        {

        }


    }
}
