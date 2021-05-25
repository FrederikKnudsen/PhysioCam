using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhysioCam.Model;

namespace PhysioCam
{
    public class ExerciseManager
    {
        public static readonly Uri URL = new Uri("https://fast-castle-50377.herokuapp.com/");
        private string strAuthorizationKey;
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            //login information and confirmation
            if (string.IsNullOrEmpty(strAuthorizationKey))
            {
                try
                {
                    UserItem userObject = new UserItem();
                    userObject.identifier = "student";
                    userObject.password = "Student1234";
                    var content = new StringContent(JsonConvert.SerializeObject(userObject), Encoding.UTF8,
                        "application/json");
                    var response = await client.PostAsync(URL + "auth/local", content);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    strAuthorizationKey = "Bearer " + JsonConvert.DeserializeObject<LoginItem>(responseBody).jwt;
                    client.DefaultRequestHeaders.Add("Authorization", strAuthorizationKey);

                    return client;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message, e);
                }

            }

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public async Task<List<ExerciseItem>> GetAllExercises()
        {
            HttpClient client = await GetClient();
            string StrResult = await client.GetStringAsync(URL + "Exercises");
            return JsonConvert.DeserializeObject<List<ExerciseItem>>(StrResult);
        }
    }
}
