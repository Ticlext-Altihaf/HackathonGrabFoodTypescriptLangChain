using HackathonGrabFoodTypescriptLangChain.Server.Models;

namespace HackathonGrabFoodTypescriptLangChain.Server.Services;

public class StubChatService : IChatService
{
    private readonly IChatSessionService _chatSessionService;

    public StubChatService(IChatSessionService chatSessionService)
    {
        _chatSessionService = chatSessionService;
    }

    public async Task<ChatResponse> SendMessage(string sessionId, string message)
    {
        var session = await _chatSessionService.GetSession(sessionId);
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
        await _chatSessionService.SaveSession(sessionId, session);
        return response;
    }

    public async Task<string> CreateSession()
    {
        var sessionId = Guid.NewGuid().ToString();
        var session = new ChatSession
        {
            History = new Dictionary<string, string>()
        };

        await _chatSessionService.SaveSession(sessionId, session);
        return sessionId;
    }

    public async Task<ChatSession?> GetSession(string sessionId)
    {
        return await _chatSessionService.GetSession(sessionId);
    }
}