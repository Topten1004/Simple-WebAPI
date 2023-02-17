using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPIWithDapperandSwagger.Models;
using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace WebAPIWithDapperandSwagger.Repository
{
    public class ContactMasterRepository : IContactMasterRepository
    {
         private readonly IConfiguration _config;

        public ContactMasterRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<ContactMaster> GetByID(int id)
        {
            try
            {
                using (IDbConnection con = Connection)
                {
                    string sQuery = "ContactFunc";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Mode", "GETBYID");
                    param.Add("@Id", id);
                    var result = await con.QueryAsync<ContactMaster>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ContactMaster>> GetAll()
        {
            try
            {
                using (IDbConnection con = Connection)
                {
                    string sQuery = "ContactFunc";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Mode", "GETALL");
                    var result = await con.QueryAsync<ContactMaster>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ContactMaster> Edit(ContactMaster contactMaster)
        {
            try
            {
                using (IDbConnection con = Connection)
                {
                    string sQuery = "ContactFunc";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Mode", "EDIT");
                    param.Add("@Id", contactMaster.Id);
                    param.Add("@FirstName", contactMaster.FirstName);
                    param.Add("@LastName", contactMaster.LastName);
                    param.Add("@CompanyName", contactMaster.CompanyName);
                    param.Add("@JobTitle", contactMaster.JobTitle);
                    param.Add("@Email", contactMaster.Email);
                    param.Add("@Notes", contactMaster.Notes);
                    param.Add("@PhoneNo", contactMaster.PhoneNo);
                    var result = await con.QueryAsync<ContactMaster>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ContactMaster> Delete(int id)
        {
            try
            {
                using (IDbConnection con = Connection)
                {
                    string sQuery = "ContactFunc";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Mode", "DELETE");
                    param.Add("@Id", id);
                    var result = await con.QueryAsync<ContactMaster>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
