using IPC.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace IPC.DAL
{
    public class RolesRepository
    {
        private string ApiBaseUrl = ConfigurationManager.AppSettings["APiBaseUrl"].ToString();

        public List<Role> GetRoles()
        {
            RestClient client = new RestClient(ApiBaseUrl);
            RestRequest request = new RestRequest("Roles/GetRoles", Method.GET);
            request.AddHeader("accept", "application/json");
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var Roles = JsonConvert.DeserializeObject<List<Role>>(response.Content);
                return Roles;
            }
            return null;
        }

        public Role GetRoleByID(Guid ID)
        {
            RestClient client = new RestClient(ApiBaseUrl);
            RestRequest request = new RestRequest("Roles/GetRole/" + ID.ToString(), Method.GET);
            request.AddHeader("accept", "application/json");
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                Role Role = JsonConvert.DeserializeObject<Role>(response.Content);
                return Role;
            }
            return null;
        }

    }
}