using System.Net;
using System.Text.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;

namespace GithubTesting;

public class Tests
{
    private RestClient client;
    private string partialUrl;
    private const string username = "daniel.takov@abv.bg";
    private const string password = "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";

    [SetUp]
    public void Setup()
    {
        this.client = new RestClient(new RestClientOptions("https://api.github.com")
        { Timeout = 3000 });
        this.partialUrl = "/repos/DTakov/postman/issues";
        this.client.Authenticator = new HttpBasicAuthenticator(username,password);

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

    [Test]
    public void Get_AllIssues()
    {
        var request = new RestRequest(partialUrl, Method.Get);

        var response = client.Execute(request);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

        foreach (var issue in issues)
        {
            Assert.That(issue.title, Is.Not.Empty);
            Assert.That(issue.number, Is.GreaterThan(0));

        }
    }
    [Test]
    public void Get_SingelIssues_WithLabels()
    {
        var request = new RestRequest($"{partialUrl}/1", Method.Get);

        var response = client.Execute(request);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var issuesWithLabels = JsonSerializer.Deserialize<Issue>(response.Content);

       
        for (int i=0; i < issuesWithLabels.labels.Count; i++)
        {
            Assert.That(issuesWithLabels.labels[i].name, Is.Not.Null);
        }
    }
    [Test]
    public void Create_Issue()
    {
        //Arange
        var request = new RestRequest(partialUrl, Method.Post);
        var issueBody = new
        {
            title = "New test issue" + DateTime.Now.Ticks,
            body = "test body",
            labels = new string[] { "bug", "critical", "release" }
        };
        request.AddBody(issueBody);

        //Act
        var response = this.client.Execute(request);
        var issue = JsonSerializer.Deserialize<Issue>(response.Content);

        //Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(issue.number, Is.GreaterThan(0));
        Assert.That(issue.title, Is.EqualTo(issueBody.title));
        Assert.That(issue.body, Is.EqualTo(issueBody.body));
    }

}
