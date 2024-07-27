namespace HackathonGrabFoodTypescriptLangChain.Server.Models;

public class ChatSession
{
    // role => message
    public Dictionary<string, string> History { get; set; }


}