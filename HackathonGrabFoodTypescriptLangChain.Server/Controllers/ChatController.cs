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
        try
        {
            return Ok(await ChatService.CreateSession());
        }
        catch (Exception e)
        {
            return BadRequest(new {message = e.Message});
        }
    }

    [HttpPost]
    [Route("{sessionId}")]
    public async Task<IActionResult> SendMessage(string sessionId, [FromBody] string message)
    {
        try
        {
            return Ok(await ChatService.SendMessage(sessionId, message));
        }
        catch (ArgumentException e)
        {
            return BadRequest(new {message = e.Message});
        }
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