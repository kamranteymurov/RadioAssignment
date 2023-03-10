using System.Text.Json;
using System.Text;
namespace ConsoleCompareLeftAndRight
{
    public class CallApi
    {
        //add
        public async Task<string> AddDataAsync(int id, string leftOrRight, string data)
        {
            Result input = new Result() { Input = data };
            using var client = new HttpClient();

            // Set the API endpoint URL
            var apiUrl = $"https://localhost:7202/v1/diff/" + id + "/" + leftOrRight;
            // Serialize the input data to JSON
            var json = System.Text.Json.JsonSerializer.Serialize(input);

            // Send the POST request with the JSON data in the request body
            var response = await client.PostAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));

            // Read the response code as a string
            var responseContent = response.StatusCode.ToString();

            return responseContent;

        }
        //diff
        public async Task<ApiResponse> CallGetDiffApi(int id)
        {
            using var client = new HttpClient();

            // Set the API endpoint URL with the id parameter
            var apiUrl = $"https://localhost:7202/v1/diff/" + id;

            // Send the GET request
            var response = await client.GetAsync(apiUrl);

            // Read the response content as a string
            var responseContent = await response.Content.ReadAsStringAsync();

            // Try to deserialize the response as an OffsetData
            ApiResponse apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseContent);
            return apiResponse;
        }

    }
}
