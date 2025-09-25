using Entities;
using Microsoft.Data.SqlClient;


namespace DataAccess
{
    public class MaterialTypeRepo
    {
        string serverName = string.Empty;

        public MaterialTypeRepo(string serverName)
        {
            this.serverName = serverName;
        }


        public List<MaterialType> GetAll()
        {
            List<MaterialType> materialTypes = new List<MaterialType>();
            string query = "SELECT * FROM MaterialTypes";
           
            using (SqlConnection con = new SqlConnection(serverName + ConnectionString.ConString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {

                    con.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        MaterialType matType = new MaterialType();
                        matType.Id = (int)dataReader["Id"];
                        matType.Name = dataReader["Name"].ToString();
                        matType.IconPath = dataReader["IconPath"].ToString();

                        materialTypes.Add(matType);

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

            return materialTypes;
        }

        public List<MaterialType> GetById(int id)
        {
            List<MaterialType> materialTypes = new List<MaterialType>();

            //TODO

            return materialTypes;
        }


        public void SaveNew(MaterialType material)
        {
            //TODO
        }

        

    }
}
