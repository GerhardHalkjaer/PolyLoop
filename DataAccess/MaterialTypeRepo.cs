using Entities;
using Microsoft.Data.SqlClient;


namespace DataAccess
{
    public class MaterialTypeRepo
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PolyLoop;
                                    Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                    Trust Server Certificate=False;Application Intent=ReadWrite;
                                    Multi Subnet Failover=False";


        public List<MaterialType> GetAll()
        {
            List<MaterialType> materialTypes = new List<MaterialType>();

            string query = "SELECT * FROM MaterialTypes";
            SqlConnection con = new SqlConnection(ConnectionString);
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


        public void SaveNew(MaterialType material)
        {

        }

        // SELECT * FROM MaterialTypes INNER JOIN SpecificTypes ON MaterialTypes.Id = SpecificTypes.MaterialTypeId

    }
}
