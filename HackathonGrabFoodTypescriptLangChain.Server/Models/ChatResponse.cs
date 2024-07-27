namespace HackathonGrabFoodTypescriptLangChain.Server.Models;

public class ChatResponse
{
    public string Message { get; set; }
    public string[] Suggestions { get; set; }
}