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
                // TODO fill
            }

            con.Close();

            return null;
        }


        public void SaveNew(MaterialType material)
        {

        }



    }
}
