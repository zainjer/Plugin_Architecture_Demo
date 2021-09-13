using Plugin_Architecture;
namespace Plugin_A;

public class SingSong : IPlugin
{
    public string PluginName {get; init;} = "Sing a Song";

    public void Invoke()
    {
        Console.WriteLine("I hurt myself today\nTo see if I still feel\nI focus on the pain\nThe only thing that's real\nThe needle tears a hole\nThe old familiar sting\nTry to kill it all away\nBut I remember everything");
    }
}
