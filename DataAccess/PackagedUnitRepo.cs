using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PackagedUnitRepo
    {

        /// <summary>
        /// get all packaged units from the db
        /// </summary>
        /// <returns>List<PackagedUnit></returns>
        public List<PackagedUnit> GetAll()
        {
            List<PackagedUnit> packagedUnits = new List<PackagedUnit>();
            string query = "SELECT PackagedUnits.*, Packagings.Name AS PackagingName, Packagings.IconPath AS PackagingIconPath, Packagings.PackagingWeight," +
                " SpecificTypes.MaterialTypeId, SpecificTypes.Name AS SpecificName, SpecificTypes.IconPath AS SpecificIconPath, MaterialTypes.Name AS MaterialName," +
                " MaterialTypes.IconPath AS MaterialIconPath FROM PackagedUnits INNER JOIN Packagings ON PackagedUnits.PackagingId = Packagings.Id INNER JOIN SpecificTypes" +
                " ON PackagedUnits.SpecificTypeId = SpecificTypes.Id INNER JOIN MaterialTypes ON SpecificTypes.MaterialTypeId = MaterialTypes.Id";

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
                        SpecificType specificType = new SpecificType();
                        MaterialType materialType = new MaterialType();
                        PackagedUnit packagedUnit = new PackagedUnit();

                        materialType.Id = (int)dataReader["MaterialTypeId"];
                        materialType.Name = dataReader["MaterialName"].ToString();
                        materialType.IconPath = dataReader["MaterialIconPath"].ToString();

                        specificType.Id = (int)dataReader["SpecificTypeId"];
                        specificType.MatType = materialType;
                        specificType.Name = dataReader["SpecificName"].ToString();
                        specificType.IconPath = dataReader["SpecificIconPath"].ToString();

                        packaging.Id = (int)dataReader["PackagingId"];
                        packaging.Name = dataReader["PackagingName"].ToString();
                        packaging.IconPath = dataReader["PackagingIconPath"].ToString();
                        packaging.PackagingWeight = (int)dataReader["PackagingWeight"];


                        packagedUnit.Id = (int)dataReader["Id"];
                        packagedUnit.ImagePath = dataReader["ImagePath"].ToString();
                        packagedUnit.weight = (int)dataReader["Weight"];
                        packagedUnit.Packaging = packaging;
                        packagedUnit.SpecificType = specificType;
                        packagedUnit.ProcessedDate = DateTime.Parse(dataReader["ProcessedDate"].ToString());
                        packagedUnit.UserPacking = (int)dataReader["UserPacking"]; //TODO: change to make a user object

                        packagedUnits.Add(packagedUnit);

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


            return packagedUnits;
        }

        public List<PackagedUnit> GetById(int id)
        {
            //TODO
            return null;
        }




        /// <summary>
        /// save new packaged unit to the db
        /// </summary>
        /// <param name="type">PackagedUnit</param>
        /// <returns>int Id</returns>
        public int SaveNew(PackagedUnit type)
        {
            
            string sql = "INSERT INTO PackagedUnits (ImagePath, Weight, StartDate, PackagingId, SpecificTypeId, UserPackingId) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@ImagePath, @Weight, @StartDate, @PackagingId, @SpecificTypeId, @UserPackingId);";

            using (SqlConnection con = new SqlConnection(ConnectionString.ConString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                try
                {
                    con.Open();


                    cmd.Parameters.AddWithValue("@ImagePath", type.ImagePath);
                    cmd.Parameters.AddWithValue("@Weight", type.weight);
                    cmd.Parameters.AddWithValue("@StartDate", type.ProcessedDate);
                    cmd.Parameters.AddWithValue("@PackagingId", type.Packaging.Id);
                    cmd.Parameters.AddWithValue("@SpecificTypeId", type.SpecificType.Id);
                    cmd.Parameters.AddWithValue("@UserPackingId", type.UserPacking);

                    return (int)cmd.ExecuteScalar(); // gets the Id and returns it

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }


                //TODO

            }
        }

        public bool Update(PackagedUnit type)
        {
            //TODO

            string sql = "UPDATE PackagedUnits SET ImagePath=@ImagePath WHERE Id = @Id";

            using (SqlConnection con = new SqlConnection(ConnectionString.ConString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                try
                {
                    con.Open();


                    cmd.Parameters.AddWithValue("@ImagePath", type.ImagePath);
                    cmd.Parameters.AddWithValue("@Id", type.Id);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }


                //TODO

            }

        }


        /// <summary>
        /// Get the last Id from the PackagedUnits table
        /// </summary>
        /// <returns></returns>
        public int GetLastId()
        {
            string query = "SELECT TOP 1 Id FROM PackagedUnits";

            int lastId = 0;

            using (SqlConnection con = new SqlConnection(ConnectionString.ConString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        lastId = (int)dataReader["Id"];

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

            //TODO
            return lastId;



            // return _context.PackagedUnits
            //       .OrderByDescending(p => p.Id)
            //       .Select(p => p.Id)
            //       .FirstOrDefault();
        }

    }
}
