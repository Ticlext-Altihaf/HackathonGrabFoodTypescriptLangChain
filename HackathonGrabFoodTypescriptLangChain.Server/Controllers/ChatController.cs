using HackathonGrabFoodTypescriptLangChain.Server.Models;
using HackathonGrabFoodTypescriptLangChain.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackathonGrabFoodTypescriptLangChain.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    protected readonly IChatService _chatService;
    private readonly ILogger<ChatController> _logger;

    public ChatController(ILogger<ChatController> logger, IChatService chatService)
    {
        _logger = logger;
        _chatService = chatService;
    }

    [HttpPost]
    [Route("")]
    public async Task<string> CreateSession()
    {
        return await _chatService.CreateSession();
    }

    [HttpPost]
    [Route("{sessionId}")]
    public async Task<ChatResponse> SendMessage(string sessionId, [FromBody] string message)
    {
        return await _chatService.SendMessage(sessionId, message);
    }

    [HttpGet]
    [Route("{sessionId}")]
    public async Task<ChatSession?> GetMessages(string sessionId)
    {
        return await _chatService.GetSession(sessionId);
    }
}