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

        private readonly string sqlGetPet = "SELECT * FROM pets WHERE pet_id = @PetId";
        private readonly string sqlGetAllPets = "SELECT * FROM pets";
        private readonly string sqlGetLikedPets = "SELECT * FROM pets " +
            "JOIN user_pet ON user_pet.pet_id = pets.pet_id " +
            "JOIN users ON users.user_id = user_pet.user_id " +
            "WHERE users.user_id = @userId;";
        private string sqlGetFilteredPetsBase = "SELECT pet_id, species_id, breed_id, agency_id, primary_image_id, primary_image_url, " +
            "thumbnail_url, name, description_text, sex, age_group, age_string, activity_level, exercise_needs, " +
            "owner_experience, size_group, vocal_level " +
            "FROM pets WHERE 1=1 ";
        private readonly string sqlGetFilteredPetsSuffix = "EXCEPT " +
            "SELECT pets.pet_id, species_id, breed_id, agency_id, primary_image_id, primary_image_url, " +
            "thumbnail_url, name, description_text, sex, age_group, age_string, activity_level, exercise_needs, " +
            "owner_experience, size_group, vocal_level " +
            "FROM pets " +
            "JOIN user_pet ON user_pet.pet_id = pets.pet_id " +
            "JOIN users ON users.user_id = user_pet.user_id " +
            "WHERE user_pet.user_id = @UserId";
        private readonly string sqlAddPet = "INSERT INTO pets(pet_id, species_id, breed_id, agency_id, " +
            "primary_image_id, primary_image_url, thumbnail_url, name, description_text, sex, age_group, " +
            "age_string, activity_level, exercise_needs, owner_experience, size_group, vocal_level) " +
            "VALUES (@PetId, @SpeciesId, @BreedId, @AgencyId, @PrimaryImageId, @PrimaryImageUrl, " +
            "@ThumbnailUrl, @Name, @DescriptionText, @Sex, @AgeGroup, @AgeString, @ActivityLevel, " +
            "@ExerciseNeeds, @OwnerExperience, @SizeGroup, @VocalLevel);";
        private readonly string sqlUpdatePet = "UPDATE pets SET pet_id = @PetId, species_id = @SpeciesId, " +
            "breed_id = @BreedId, agency_id = @AgencyId, primary_image_id = @PrimaryImageId, " +
            "primary_image_url = @PrimaryImageUrl, thumbnail_url = @ThumbnailUrl, name = @Name, " +
            "description_text = @DescriptionText, sex = @Sex, age_group = @AgeGroup, age_string = @AgeString, " +
            "activity_level = @ActivityLevel, exercise_needs = @ExerciseNeeds, owner_experience = @OwnerExperience," +
            "size_group = @SizeGroup, vocal_level = @VocalLevel;";
        private readonly string sqlDeletePet = "DELETE FROM pets WHERE pet_id = @petId";

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
                    AddPetParameters(pet, cmd);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                    cmd.Parameters.AddWithValue("@PetId", petId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        result = ReadPet(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                        result.Add(ReadPet(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public IEnumerable<Pet> GetLikedPets(int userId)
        {
            List<Pet> result = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetLikedPets, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        result.Add(ReadPet(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public IEnumerable<Pet> GetFilteredPets(SearchCriteria search)
        {
            List<Pet> result = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetFilteredPetsBase, conn);
                    cmd.Parameters.AddWithValue("@UserId", search.UserId);

                    if (search.SpeciesId != 0)
                    {
                        cmd.CommandText = cmd.CommandText + " AND species_id = @SpeciesId ";
                        cmd.Parameters.AddWithValue("@SpeciesId", search.SpeciesId);
                    }
                    if (search.BreedIds != null)
                    {
                        cmd.CommandText += " AND ( 1=0";
                        for (int i = 0; i < search.BreedIds.Count; i++)
                        {
                            cmd.CommandText = cmd.CommandText + $" OR breed_id = @breedId{i}";
                            cmd.Parameters.AddWithValue($"@breedId{i}", search.BreedIds[i]);
                        }
                        cmd.CommandText += ") ";
                    }

                    cmd.CommandText += sqlGetFilteredPetsSuffix;
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        result.Add(ReadPet(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool UpdatePet(Pet pet)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlUpdatePet, conn);
                    AddPetParameters(pet, cmd);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

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
                Console.WriteLine(ex.Message);
            }
            return result;

        }

        // Helper methods
        private void AddPetParameters(Pet pet, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@PetId", pet.PetId);
            cmd.Parameters.AddWithValue("@SpeciesId", pet.SpeciesId);
            cmd.Parameters.AddWithValue("@BreedId", pet.BreedId);
            cmd.Parameters.AddWithValue("@AgencyId", pet.AgencyId);
            cmd.Parameters.AddWithValue("@PrimaryImageId", pet.PrimaryImageId);
            cmd.Parameters.AddWithValue("@PrimaryImageUrl", pet.PrimaryImageUrl);
            cmd.Parameters.AddWithValue("@ThumbnailUrl", pet.ThumbnailUrl);
            cmd.Parameters.AddWithValue("@Name", pet.Name);
            cmd.Parameters.AddWithValue("@DescriptionText", pet.DescriptionText);
            cmd.Parameters.AddWithValue("@Sex", pet.Sex);
            cmd.Parameters.AddWithValue("@AgeGroup", pet.AgeGroup);
            cmd.Parameters.AddWithValue("@AgeString", pet.AgeString);
            cmd.Parameters.AddWithValue("@ActivityLevel", pet.ActivityLevel);
            cmd.Parameters.AddWithValue("@ExerciseNeeds", pet.ExerciseNeeds);
            cmd.Parameters.AddWithValue("@OwnerExperience", pet.OwnerExperience);
            cmd.Parameters.AddWithValue("@SizeGroup", pet.SizeGroup);
            cmd.Parameters.AddWithValue("@VocalLevel", pet.VocalLevel);
        }

        private Pet ReadPet(SqlDataReader reader)
        {
            Pet pet = new Pet();

            pet.PetId = Convert.ToInt32(reader["pet_id"]);
            pet.SpeciesId = Convert.ToInt32(reader["species_id"]);
            pet.BreedId = Convert.ToInt32(reader["breed_id"]);
            pet.AgencyId = Convert.ToInt32(reader["agency_id"]);
            pet.PrimaryImageId = Convert.ToInt32(reader["primary_image_id"]);
            pet.PrimaryImageUrl = Convert.ToString(reader["primary_image_url"]);
            pet.ThumbnailUrl = Convert.ToString(reader["thumbnail_url"]);
            pet.Name = Convert.ToString(reader["name"]);
            pet.DescriptionText = Convert.ToString(reader["description_text"]);
            pet.Sex = Convert.ToString(reader["sex"]);
            pet.AgeGroup = Convert.ToString(reader["age_group"]);
            pet.AgeString = Convert.ToString(reader["age_string"]);
            pet.ActivityLevel = Convert.ToString(reader["activity_level"]);
            pet.ExerciseNeeds = Convert.ToString(reader["exercise_needs"]);
            pet.OwnerExperience = Convert.ToString(reader["owner_experience"]);
            pet.SizeGroup = Convert.ToString(reader["size_group"]);
            pet.VocalLevel = Convert.ToString(reader["vocal_level"]);

            return pet;
        }
    }
}
