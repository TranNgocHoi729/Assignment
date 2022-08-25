using MEGIDDO.Client.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MEGIDDO.Client.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet("users")]
        public async Task<IActionResult> GetListUser()
        {
            HttpClient _httpClient = new HttpClient();
            var user = new UserLoginModel
            {
                Username = "Admin1",
                Password = "123456789"
            };
            var _user = JsonSerializer.Serialize(user);
            var request = new HttpRequestMessage(HttpMethod.Post, @"https://localhost:5001/Megiddo/Authentication/login");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(_user, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var _token = JsonSerializer.Deserialize<TokenDto>(content);

            HttpClient _httpClient2 = new HttpClient();
            var request2 = new HttpRequestMessage(HttpMethod.Get, @"https://localhost:44397/api/listUser/user");
            request2.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token.token);

            var response2 = await _httpClient2.SendAsync(request2);
            response2.EnsureSuccessStatusCode();

            var content2 = await response2.Content.ReadAsStringAsync();
            return Ok(content2);
        }


    }
}
