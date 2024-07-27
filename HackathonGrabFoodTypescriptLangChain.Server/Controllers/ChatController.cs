using HackathonGrabFoodTypescriptLangChain.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackathonGrabFoodTypescriptLangChain.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly ILogger<ChatController> _logger;
    protected readonly IChatService ChatService;

    public ChatController(ILogger<ChatController> logger, IChatService chatService)
    {
        _logger = logger;
        ChatService = chatService;
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateSession()
    {
        var sessionId = await ChatService.CreateSession();
        return Ok(new { Message = "Ok", Data = sessionId });
    }

    [HttpPost]
    [Route("{sessionId}")]
    public async Task<IActionResult> SendMessage(string sessionId, [FromBody] string message)
    {

        var response = await ChatService.SendMessage(sessionId, message);
        return Ok(new { Message = "Ok", Data = response });
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

        return Ok(new { Message = "Ok", Data = result });
    }
}