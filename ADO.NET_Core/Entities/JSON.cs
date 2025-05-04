using Newtonsoft.Json;

namespace ADO.NET_Core.Entities;

public class JsonBase
    {
        readonly HttpClient httpClient = new();
        public async Task<List<Post>?> GetPostsApi()
        {
            try
            {
                string APIUrl = @"https://jsonplaceholder.typicode.com/posts";
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(APIUrl);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var data = await httpResponseMessage.Content.ReadAsStringAsync();
                    var posts = JsonConvert.DeserializeObject<List<Post>>(data);
                    return posts;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Operation failed : {httpResponseMessage.StatusCode} due to {httpResponseMessage.ReasonPhrase}");
                    Console.ResetColor();
                    return null;
                }
            }
            catch (HttpRequestException exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Request error : {exception.Message}");
                Console.ResetColor();
                return null;
            }
        }
    }
