using HackathonGrabFoodTypescriptLangChain.Server.Models;

namespace HackathonGrabFoodTypescriptLangChain.Server.Services;

public interface IChatSessionService
{
    public Task SaveSession(string sessionId, ChatSession session);
    public Task<ChatSession?> GetSession(string sessionId);
}