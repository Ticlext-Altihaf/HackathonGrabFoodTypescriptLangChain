using HackathonGrabFoodTypescriptLangChain.Server.Models;
using HackathonGrabFoodTypescriptLangChain.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackathonGrabFoodTypescriptLangChain.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    protected readonly IChatService ChatService;
    private readonly ILogger<ChatController> _logger;

    public ChatController(ILogger<ChatController> logger, IChatService chatService)
    {
        _logger = logger;
        ChatService = chatService;
    }

    [HttpPost]
    [Route("")]
    public async Task<string> CreateSession()
    {
        return await ChatService.CreateSession();
    }

    [HttpPost]
    [Route("{sessionId}")]
    public async Task<ChatResponse> SendMessage(string sessionId, [FromBody] string message)
    {
        return await ChatService.SendMessage(sessionId, message);
    }

    [HttpGet]
    [Route("{sessionId}")]
    public async Task<IActionResult> GetMessages(string sessionId)
    {
        var result = await ChatService.GetSession(sessionId);
        if (result == null)
        {
            // 404
            return NotFound();

        }
        return Ok(result);
    }
}