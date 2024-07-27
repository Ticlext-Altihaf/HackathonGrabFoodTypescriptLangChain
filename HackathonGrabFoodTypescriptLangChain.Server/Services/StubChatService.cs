using HackathonGrabFoodTypescriptLangChain.Server.Models;

namespace HackathonGrabFoodTypescriptLangChain.Server.Services;

public class StubChatService : IChatService
{
    private readonly Dictionary<string, ChatSession> _sessions = new Dictionary<string, ChatSession>();

    public Task<ChatResponse> SendMessage(string sessionId, string message)
    {
        var session = _sessions.GetValueOrDefault(sessionId);
        if (session == null)
        {
            throw new ArgumentException("Invalid session ID");
        }

        session.History.Add("user", message);
        var response = new ChatResponse
        {
            Message = "Hello, how can I help you?",
            Suggestions = new string[] {"Order food", "Track order", "Cancel order"}
        };
        return Task.FromResult(response);
    }

    public Task<string> CreateSession()
    {
        var sessionId = Guid.NewGuid().ToString();
        var session = new ChatSession
        {
            History = new Dictionary<string, string>()
        };

        return Task.FromResult(sessionId);
    }

    public Task<ChatSession?> GetSession(string sessionId)
    {
        return Task.FromResult(_sessions.GetValueOrDefault(sessionId));
    }
}