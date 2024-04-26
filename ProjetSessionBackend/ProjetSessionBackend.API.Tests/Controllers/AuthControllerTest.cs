using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetSessionBackend.API.Controllers;

namespace ProjetSessionBackend.API.Tests.Controllers;

[TestClass]
[TestSubject(typeof(AuthController))]
public class AuthControllerTest
{
    private const string Url = "http://localhost:5117";
    
    [TestMethod]
    public async Task POST_Login_Returns_OK()
    {
        // Arrange
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, ApiRoute("/login"));

        // Act
        var response = await client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }
    
    [TestMethod]
    public async Task POST_Register_Returns_OK()
    {
        // Arrange
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, ApiRoute("/register"));

        // Act
        var response = await client.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }
    
    private string ApiRoute(string route) => $"{Url}/{route}";
}