using Entities;
using Microsoft.Data.SqlClient;


namespace DataAccess
{
    public class MaterialTypeRepo
    {
        


        public List<MaterialType> GetAll()
        {
            List<MaterialType> materialTypes = new List<MaterialType>();

            string query = "SELECT * FROM MaterialTypes";
            SqlConnection con = new SqlConnection(ConnectionString.ConString);
            SqlCommand cmd = new SqlCommand(query, con);
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

            con.Close();

            return materialTypes;
        }

        public List<MaterialType> GetById(int id)
        {
            List<MaterialType> materialTypes = new List<MaterialType>();






            return materialTypes;
        }


        public void SaveNew(MaterialType material)
        {

        }

        // SELECT * FROM MaterialTypes INNER JOIN SpecificTypes ON MaterialTypes.Id = SpecificTypes.MaterialTypeId

    }
}
