using System.Net;
using System.Net.Mime;
using System.Text;
using ZenDriver.API.Security.Domain.Services.Communication;
using ZenDriver.API.Security.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace ZenDriver.API.Tests.Steps;

[Binding]
public sealed class UsersServiceStepDefinitions : WebApplicationFactory<Program>
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly WebApplicationFactory<Program> _factory;

    public UsersServiceStepDefinitions(WebApplicationFactory<Program> factory, HttpClient client, Uri baseUri, Task<HttpResponseMessage> response)
    {
        _factory = factory;
        Client = client;
        BaseUri = baseUri;
        Response = response;
    }
    
    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    
    private Task<HttpResponseMessage> Response { get; set; }
    
    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/users is available")]
    public void GivenTheEndpointHttpsLocalhostApiVUsersIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/tutorials");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }
    
    [When(@"a Post Request is sent")]
    public void WhenAPostRequestIsSent(Table saveUserResource)
    {
        var resource = saveUserResource.CreateSet<RegisterRequest>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"A Response is received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"a User Resource is included in Response Body")]
    public async Task ThenAUserResourceIsIncludedInResponseBody(Table expectedUserResource)
    {
        var expectedResource = expectedUserResource.CreateSet<UserResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<UserResource>(responseData);
        Assert.Equal(expectedResource.Username, resource.Username);
    }

    [Given(@"A User is already stored")]
    public async void GivenUserIsAlreadyStored(Table saveUserResource)
    {
        var resource = saveUserResource.CreateSet<RegisterRequest>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var responseResource = JsonConvert.DeserializeObject<UserResource>(responseData);
        Assert.Equal(resource.Username, responseResource.Username);
    }

    [Then(@"An Error Message is returned with value ""(.*)""")]
    public void ThenAnErrorMessageIsReturnedWithValue(string expectedMessage)
    {
        var message = Response.Result.Content.ReadAsStringAsync().Result;
        Assert.Equal(expectedMessage, message);
    }
}