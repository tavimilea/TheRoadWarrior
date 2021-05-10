using System.Net.Http;
using System.Threading.Tasks;
using TheRoadWarrior;
using Xunit;

namespace IntegrationTests
{
    public class RegisterTest: IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public RegisterTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }
        [Fact]
        public async Task TestPostStockItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/Register",
                Body = new
                {
                    password = "aaa",
                    passwordCheck  = "aaa",
                    username  = "aaaa"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
