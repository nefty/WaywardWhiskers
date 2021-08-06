using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class AdminSqlDAO : IAdminDAO
    {
        private readonly string connectionString;
        private readonly string sqlUpdateUserRole = "UPDATE users SET user_role = @role WHERE user_id = @userId;";
        private readonly string sqlDeleteUser = "DELETE FROM users WHERE user_id = @userId;";


        public AdminSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        public bool UpdateUserRole(User user)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlUpdateUserRole, conn);
                    cmd.Parameters.AddWithValue("@userId", user.UserId);
                    cmd.Parameters.AddWithValue("@role", user.Role);

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

        public bool DeleteUser(int userId)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlDeleteUser, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

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
