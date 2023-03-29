using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsumoDeAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //HttpClient client = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/") };
            // var response = await client.GetAsync("users");
            // var content = await response.Content.ReadAsStringAsync();

            //var users = JsonConvert.DeserializeObject<User[]>(content);

            //foreach (var item in users)
            //{
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.Email);
            //}


            await Post();

        }
         
        public static async Task Post()
        {
            var  httpClient = new HttpClient();
            var request = new HttpRequestMessage();
            var objeto = new { 
                equipaID = "66B1AF4D-CB9C-4D66-8C88-C13ACB81D758", 
                funcionarios =new List<dynamic> { }
                    
                }; 
            var content = ToRequest(objeto);

            var response = await httpClient.PostAsync("http://160.242.22.61:81/api/IsEmployee/notificar-aprovador", content);
        }

        private static StringContent ToRequest(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            return data;
        }


    }

}