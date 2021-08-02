using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PetSqlDAO : IPetDAO
    {
        private readonly string connectionString;

        private readonly string sqlGetPet = "SELECT * FROM pets WHERE pet_id = @petId";
        private readonly string sqlGetAllPets = "SELECT * FROM pets";
        private readonly string sqlAddPet = "INSERT INTO pets(pet_name, pet_type, pet_breed, pet_age, pet_description, pet_image_url, agency_id) " +
                                            "VALUES (@petName, @petType, @petBreed, @petAge, @petDescription, @petUrl, @agencyId)";

        public PetSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddPet(Pet pet)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddPet, conn);
                    cmd.Parameters.AddWithValue("@petName", pet.Name);
                    cmd.Parameters.AddWithValue("@petType", pet.Type);
                    cmd.Parameters.AddWithValue("@petBreed", pet.Breed);
                    cmd.Parameters.AddWithValue("@petAge", pet.Age);
                    cmd.Parameters.AddWithValue("@petDescription", pet.Description);
                    cmd.Parameters.AddWithValue("@petURL", pet.ImageUrl);
                    cmd.Parameters.AddWithValue("@agencyId", pet.AgencyId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {

            }
            return result;

        }


        public Pet GetPet(int petId)
        {
            Pet result = new Pet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetPet, conn);
                    cmd.Parameters.AddWithValue("@petId", petId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        result.Name = Convert.ToString(reader["pet_name"]);
                        result.Type = Convert.ToString(reader["pet_type"]);
                        result.Breed = Convert.ToString(reader["pet_breed"]);
                        result.Age = Convert.ToInt32(reader["pet_age"]);
                        result.Description = Convert.ToString(reader["pet_description"]);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            List<Pet> result = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllPets, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        Pet pet = new Pet();
                        pet.Name = Convert.ToString(reader["pet_name"]);
                        pet.Type = Convert.ToString(reader["pet_type"]);
                        pet.Breed = Convert.ToString(reader["pet_breed"]);
                        pet.Age = Convert.ToInt32(reader["pet_age"]);
                        pet.Description = Convert.ToString(reader["pet_description"]);
                        result.Add(pet);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        //public bool UpdatePet(Pet pet)
        //{

        //}

        public bool DeletePet(int petId)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlDeletePet, conn);
                    cmd.Parameters.AddWithValue("@petId", petId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {

            }
            return result;

        }
    }
}
