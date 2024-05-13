using ConsoleChatGpt;
using System.Net.Http.Json;

string apiKey = "API-KEY";
string endPoint = "https://api.openai.com/v1/chat/completions";

List<Message> messages = new List<Message>();

var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

while (true)
{
    Console.Write("User: ");
    var content = Console.ReadLine();

    if (content is not { Length: > 0 })
        break;

var message = new Message() { Role = "user", Content = content };
messages.Add(message);

var requestData = new Request()
{
    ModelId = "gpt-3.5-turbo",
    Messages = messages
};

using var response = await httpClient.PostAsJsonAsync(endPoint, requestData);

if (!response.IsSuccessStatusCode)
{
    Console.WriteLine($"{(int)response.StatusCode} {response.StatusCode}");
    break;
}

ResponseData? responseData = await response.Content.ReadFromJsonAsync<ResponseData>();
var choices = responseData?.Choices ?? new List<Choice>();

if (choices.Count == 0)
    Console.WriteLine("No choices were returned by the API");



var choice = choices[0];
var responseMessage = choice.Message;
messages.Add(responseMessage);
var responseText = responseMessage.Content.Trim();
Console.WriteLine($"ChatGPT: {responseText}");
}




