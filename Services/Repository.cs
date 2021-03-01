using Dapper;
using GroupsProviders.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GroupsProviders.Services
{
    public class Repository : IRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly string getGroupsAndProviders;
        public Repository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetSection("ConnectionStrings")["GroupsAndProvidersConnectionString"];
            getGroupsAndProviders = configuration.GetSection("StoredProcedures")["getGroupsAndProviders"];
        }
        public async Task<List<GroupsViewModel>> GetGroups()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    var groups = sqlConnection.QueryAsync<GroupsViewModel>(getGroupsAndProviders, null,
                    null, null, System.Data.CommandType.StoredProcedure).GetAwaiter().GetResult();
                    return groups.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error 500");
                }
            }
        }
    }
}
