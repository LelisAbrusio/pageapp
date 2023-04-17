using Newtonsoft.Json;
using System.Diagnostics;

namespace PageApplication.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;
        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> GetItemsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                ApiResponse? apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);

                if (apiResponse == null)
                {
                    return this.GetItems();
                }

                List<string> items = new List<string>
                {
                    $"User ID: {apiResponse.UserId}",
                    $"ID: {apiResponse.Id}",
                    $"Title: {apiResponse.Title}",
                    $"Completed: {apiResponse.Completed}"
                };

                return items;
            }
        }
        public List<string> GetItems()
        {
            return new List<string> { "Person A", "Product B", "Animal C", "City D", "Food E", "Movie F", "Book G", "Country H", "Language I" };
        }
    }
}
