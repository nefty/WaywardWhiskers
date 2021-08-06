using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;


namespace Capstone.DAO
{
    public class AgencySqlDAO : IAgencyDAO
    {
        private readonly string connectionString;
        private readonly string sqlGetAgency = "SELECT * FROM agencies WHERE agency_id = @agencyId";
        private readonly string sqlGetAllAgencies = "SELECT agency_id, agency_name, address, address2, state, city_name, postal_code, agency_description FROM agencies JOIN cities ON agencies.city_id = cities.city_id";
        private readonly string sqlAddAgency = "INSERT INTO agencies(agency_name, address, address2, state, city_id, postal_code, agency_description) " +
                                            "VALUES (@agencyName, @agencyAddress, @address2, @agencyState, (SELECT city_id FROM cities WHERE city_name = @agencyCity) , @postalCode, @agencyDescription)";
        private readonly string sqlUpdateAgency = "UPDATE agencies SET agency_name = @agencyName, address = @agencyAddress, address2 = @address2, state = @agencyState, " +
                                               "city_id = (SELECT city_id FROM cities WHERE city_name = @agencyCity), postal_code = @postalCode, agency_description = @agencyDescription;";
        private readonly string sqlDeleteAgency = "DELETE FROM pets WHERE agency_id = @agencyId; " +
                                                  "DELETE FROM agencies WHERE agency_id = @agencyId;";

        public AgencySqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddAgency(Agency agency)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddAgency, conn);
                    cmd.Parameters.AddWithValue("@agencyName", agency.Name);
                    cmd.Parameters.AddWithValue("@agencyAddress", agency.Address);
                    cmd.Parameters.AddWithValue("@address2", agency.Address2);
                    cmd.Parameters.AddWithValue("@agencyState", agency.State);
                    cmd.Parameters.AddWithValue("@agencyCity", agency.City);
                    cmd.Parameters.AddWithValue("@postalCode", agency.PostalCode);
                    cmd.Parameters.AddWithValue("@agencyDescription", agency.Description);

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

        public IEnumerable<Agency> GetAllAgencies()
        {
            List<Agency> result = new List<Agency>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllAgencies, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        Agency agency = new Agency();
                        agency.Id = Convert.ToInt32(reader["agency_id"]);
                        agency.Name = Convert.ToString(reader["agency_name"]);
                        agency.Address = Convert.ToString(reader["address"]);
                        agency.Address2 = Convert.ToString(reader["address2"]);
                        agency.City = Convert.ToString(reader["city_name"]);
                        agency.State = Convert.ToString(reader["state"]);
                        agency.PostalCode = Convert.ToInt32(reader["postal_code"]);
                        agency.Description = Convert.ToString(reader["agency_description"]);
                        result.Add(agency);

                    }

                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public Agency GetAgency(int agencyId)
        {
            Agency result = new Agency();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAgency, conn);
                    cmd.Parameters.AddWithValue("@agencyId", agencyId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        result.Id = Convert.ToInt32(reader["agency_id"]);
                        result.Name = Convert.ToString(reader["agency_name"]);
                        result.Address = Convert.ToString(reader["address"]);
                        result.Address2 = Convert.ToString(reader["address2"]);
                        result.City = Convert.ToString(reader["city_name"]);
                        result.State = Convert.ToString(reader["state"]);
                        result.PostalCode = Convert.ToInt32(reader["postal_code"]);
                        result.Description = Convert.ToString(reader["agency_description"]);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }
        public bool UpdateAgency(Agency agency)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlUpdateAgency, conn);
                    cmd.Parameters.AddWithValue("@agencyName", agency.Name);
                    cmd.Parameters.AddWithValue("@agencyAddress", agency.Address);
                    cmd.Parameters.AddWithValue("@address2", agency.Address2);
                    cmd.Parameters.AddWithValue("@agencyState", agency.State);
                    cmd.Parameters.AddWithValue("@agencyCity", agency.City);
                    cmd.Parameters.AddWithValue("@postalCode", agency.PostalCode);
                    cmd.Parameters.AddWithValue("@agencyDescription", agency.Description);

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

        public bool DeleteAgency(int agencyId)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlDeleteAgency, conn);
                    cmd.Parameters.AddWithValue("@agencyId", agencyId);

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
