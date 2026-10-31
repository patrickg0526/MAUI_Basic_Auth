using System.Net.Http.Headers;
using System.Text;

namespace MauiBasicAuth.DataAccess
{
    public class UserAuthentication
    {
        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            using (var client = new HttpClient())
            {
                // Set the base address of the API (port must match the running BasicAuthWS)
                client.BaseAddress = new Uri("http://localhost:5081/");

                // Create the authentication header value
                var authToken =
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", authToken);

                // Set the endpoint to use the Values controller
                var endpoint = "api/Values";

                // Send a GET request
                var response = await client.GetAsync(endpoint);

                // Return true if authentication succeeded
                return response.IsSuccessStatusCode;
            }
        }
    }
}
