using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;
using System.Xml.Linq;


namespace GithubTestsWithRestSharp.Tests
{
    public class Tests
    {
        private RestClient client;
        private string partialUrl;
        private const string username = "gabcho7";
        private const string token = "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";


        [SetUp]
        public void Setup()
        {
            this.client = new RestClient(new RestClientOptions("https://api.github.com")
            { Timeout = 3000 });
            this.partialUrl = "/repos/gabcho7/postman/issues";
            this.client.Authenticator = new HttpBasicAuthenticator(username, token);
        }

        [Test]
        public void Get_Single_Issue()
        {
            var request = new RestRequest($"{partialUrl}/1", Method.Get);

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK)); 
        }

        [Test]
        public void Get_All_Issue()
        {
            var request = new RestRequest(partialUrl, Method.Get);
            
            var response = this.client.Execute(request);

            var responseIssue = JsonSerializer.Deserialize<List<Issue>>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            foreach (var issue in responseIssue)
            {
                Assert.That(issue.id, Is.TypeOf<int>());
                Assert.That(issue.title, Is.TypeOf<string>());
               
            }
        }

        [Test]
        public void Create_Issue()
        {
            var request = new RestRequest($"{partialUrl}", Method.Post);
            var issueBody = new
            {
                title = "New test issue" + DateTime.Now,
                body = "test body",
                
            };
            request.AddBody(issueBody);

            var response = this.client.Execute(request);

            var responseIssue = JsonSerializer.Deserialize<Issue>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(responseIssue.number, Is.GreaterThan(0));
            Assert.That(responseIssue.id, Is.TypeOf<int>());
            Assert.That(responseIssue.title, Is.TypeOf<string>());
            Assert.That(issueBody.title, Is.EqualTo(responseIssue.title));
            Assert.That(issueBody.body, Is.EqualTo(responseIssue.body));
        }

        [Test]
        public void Create_Issue_With_Invalid_Data()
        {
            var request = new RestRequest($"{partialUrl}", Method.Post);
            var issueBody = new
            {
               
                body = "The tittle(required) is missing. Only the body is provided"

            };
            request.AddBody(issueBody);

            var response = this.client.Execute(request);

            var responseIssue = JsonSerializer.Deserialize<Issue>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.UnprocessableEntity));
           
        }

        [Test]
        public void Create_Comment_For_Single_Issue()
        {
            var request = new RestRequest($"{partialUrl}/1/comments", Method.Post);
            var issueBody = new
            {

                owner = "gabcho7",
                repo = "postman",
                issue_number = "1",
                title = "Bug was fixed",
                body = "Body content"

            };
            request.AddBody(issueBody);

            var response = this.client.Execute(request);

            var responseIssue = JsonSerializer.Deserialize<Issue>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

        }

        [Test]
        public void Update_Issue()
        {
            var request = new RestRequest($"{partialUrl}/1", Method.Patch);
            var issueBody = new
            {

                owner = "gabcho7",
                repo = "postman",
                issue_number = "1",
                title = "Bug was fixed",
                body = "Body content"

            };
            request.AddBody(issueBody);

            var response = this.client.Execute(request);

            var responseIssue = JsonSerializer.Deserialize<Issue>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseIssue.id, Is.TypeOf<int>());
            Assert.That(responseIssue.title, Is.TypeOf<string>());

        }
    }
}