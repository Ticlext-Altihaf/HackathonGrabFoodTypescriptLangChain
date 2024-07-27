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

    [HttpPost("createSession")]
    public async Task<string> CreateSession()
    {
        return await _chatService.CreateSession();
    }
}