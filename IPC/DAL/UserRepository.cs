using IPC.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Script.Serialization;


namespace IPC.DAL
{
    public class UserRepository
    {
        private string ApiBaseUrl = ConfigurationManager.AppSettings["APiBaseUrl"].ToString();

        public List<User> GetUsers()
        {
            RestClient client = new RestClient(ApiBaseUrl);
            RestRequest request = new RestRequest("Users/GetUsers", Method.GET);
            request.AddHeader("accept", "application/json");
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var users = JsonConvert.DeserializeObject<List<User>>(response.Content);
                return users;
            }
            return null;
        }

        public User GetUserByID(Guid ID)
        {
            RestClient client = new RestClient(ApiBaseUrl);
            RestRequest request = new RestRequest("Users/GetUser/" + ID.ToString(), Method.GET);
            request.AddHeader("accept", "application/json");
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                User user = JsonConvert.DeserializeObject<User>(response.Content);
                return user;
            }
            return null;
        }

        public bool EditUser(Guid ID, User user)
        {
            RestClient client = new RestClient(ApiBaseUrl);
            RestRequest request = new RestRequest("Users/PutUser/" + ID.ToString(), Method.PUT);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new JavaScriptSerializer().Serialize(user));
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return true;
            }
            return false;
        }

        public User CreateUser(User user)
        {
            RestClient client = new RestClient(ApiBaseUrl);
            RestRequest request = new RestRequest("Users/PostUser", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new JavaScriptSerializer().Serialize(user));
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                user = JsonConvert.DeserializeObject<User>(response.Content);
                return user;
            }
            return null;
        }

        public bool DeleteUser(Guid ID)
        {
            RestClient client = new RestClient(ApiBaseUrl);
            RestRequest request = new RestRequest("Users/DeleteUser/" + ID.ToString(), Method.DELETE);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return true;
            }
            return false;
        }

        public User FindUser(LoginVM login)
        {
            RestClient client = new RestClient(ApiBaseUrl);
            RestRequest request = new RestRequest("Users/FindUser", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new JavaScriptSerializer().Serialize(login));
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                User user = JsonConvert.DeserializeObject<User>(response.Content);
                return user;
            }
            return null;
        }
    }
}