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

            //TODO
            return packagedUnits;
        }

        public List<PackagedUnit> GetById(int id)
        {
            //TODO
            return null;
        }

        public void SaveNew(PackagedUnit type)
        {
            //TODO
        }

    }
}
