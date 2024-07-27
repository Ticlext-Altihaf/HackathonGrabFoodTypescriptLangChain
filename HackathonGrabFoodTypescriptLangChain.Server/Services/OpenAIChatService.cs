using HackathonGrabFoodTypescriptLangChain.Server.Models;

namespace HackathonGrabFoodTypescriptLangChain.Server.Services;

public class OpenAIChatService : IChatService
{

    private readonly IChatSessionService _chatSessionService;

    public OpenAIChatService(IChatSessionService chatSessionService)
    {
        _chatSessionService = chatSessionService;
    }

    public Task<ChatResponse> SendMessage(string sessionId, string message)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateSession()
    {
        throw new NotImplementedException();
    }

    public Task<ChatSession?> GetSession(string sessionId)
    {
        throw new NotImplementedException();
    }
}