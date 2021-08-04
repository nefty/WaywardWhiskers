using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class AdminSqlDAO : IAdmin
    {
        private User user = new User();
        private readonly string connectionString;
        private readonly string sqlUpdateUserRole = "UPDATE users SET user_role = 'admin' WHERE user_id = @user_id";


        public AdminSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

    }
}
