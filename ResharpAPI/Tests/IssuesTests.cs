using System.Net;
using System.Text.Json;
using NUnit.Framework;
using RestSharp;

namespace GithubTesting;

public class Tests
{
    private RestClient client;
    private string partialUrl;

    [SetUp]
    public void Setup()
    {
        this.client = new RestClient(new RestClientOptions("https://api.github.com")
        { Timeout = 3000 });
        this.partialUrl = "/repos/DTakov/postman/issues";
        
    }

    [Test]
    public void Get_Single_Issue()
    {
        var request = new RestRequest($"{partialUrl}/2", Method.Get);

        var response = client.Execute(request);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var issue = JsonSerializer.Deserialize<Issue>(response.Content);
        Assert.That(issue.title, Is.EqualTo("Second issue"));

    }
}
