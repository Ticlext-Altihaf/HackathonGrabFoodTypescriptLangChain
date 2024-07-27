using System.Collections.Concurrent;
using HackathonGrabFoodTypescriptLangChain.Server.Models;

namespace HackathonGrabFoodTypescriptLangChain.Server.Services;

public class InMemoryChatSessionService : IChatSessionService
{
    private readonly ConcurrentDictionary<string, ChatSession> _sessions = new();

    public Task SaveSession(string sessionId, ChatSession session)
    {
        _sessions[sessionId] = session;
        return Task.CompletedTask;
    }

    public Task<ChatSession?> GetSession(string sessionId)
    {
        return Task.FromResult(_sessions.GetValueOrDefault(sessionId));
    }
}