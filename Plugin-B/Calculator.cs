using Plugin_Architecture;

namespace Plugin_B;
public class Calculator : IPlugin
{
    public string PluginName {get; init;} = "Calculator";

    public void Invoke()
    {
        System.Console.WriteLine("Welcome to Calculator~!");
        System.Console.WriteLine("Ok i can implement an entire calculator cli here if i want! but for now...\nPress enter for a surprise!");
        Console.ReadLine();
        System.Console.WriteLine("2 + 2 = 4 \t Bet you didnt' expect that :D ~ bye bye");
    }
}
