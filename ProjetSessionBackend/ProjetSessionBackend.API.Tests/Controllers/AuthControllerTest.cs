using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProjetSessionBackend.API.Controllers;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs;
using ProjetSessionBackend.Infrastructure.Repositories;

namespace ProjetSessionBackend.API.Tests.Controllers;

[TestClass]
[TestSubject(typeof(AuthController))]
public class AuthControllerTest
{
    private const string Url = "http://localhost:5117";
    
    private HttpClient _http;
    private JsonSerializerSettings _jsonSettings;
    // private readonly IAuthRepository _repository = new AuthRepository(new Mapper(new MapperConfiguration(new MapperConfigurationExpression())));

    [TestInitialize]
    public void Setup()
    {
        _http = new HttpClient();
        _jsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    ProcessDictionaryKeys = true
                }
            }
        };
    }

    [TestMethod]
    public async Task POST_Login_As_Admin_Returns_OK()
    {
        
        // Arrange
        var body = new UserLoginResponse
        {
            Email = "bob.dole@example.com",
            Password = "Omega123*"
        };
        
        var request = MakePostRequest("/login", body);

        // Act
        var response = await _http.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }
    
    [TestMethod]
    public async Task POST_Register_Returns_OK()
    {
        // Arrange
        var body = new RegisterResponse
        {
            Firstname = "bob",
            Lastname = "dole",
            Email = "bob.dole@example.com",
            Password = "Omega123*"
        };
        
        var request = MakePostRequest("/register", body);

        // Act
        var response = await _http.SendAsync(request);

        // Assert
        response.EnsureSuccessStatusCode();
    }
    
    private HttpRequestMessage MakePostRequest(string route, object body = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, ApiRoute(route));
        
        if (body == null) 
            return request;
        
        var json = JsonConvert.SerializeObject(body, _jsonSettings);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        return request;
    }
    
    private static string ApiRoute(string route) => $"{Url}{route}";
}