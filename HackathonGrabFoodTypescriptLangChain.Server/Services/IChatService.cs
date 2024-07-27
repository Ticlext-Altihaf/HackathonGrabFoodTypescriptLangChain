using HackathonGrabFoodTypescriptLangChain.Server.Models;

namespace HackathonGrabFoodTypescriptLangChain.Server.Services;

public interface IChatService
{


    public Task<ChatResponse> SendMessage(string sessionId, string message);

    public Task<string> CreateSession();
    public Task<ChatSession?> GetSession(string sessionId);

}