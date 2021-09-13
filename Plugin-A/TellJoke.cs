using Plugin_Architecture;
namespace Plugin_A
{
    public class TellJoke : IPlugin
    {
        public string PluginName {get; init;} = "Tell a Joke";

        public void Invoke()
        {
            System.Console.WriteLine("What do you call an Aligator in vest?\n An Investigator!");
        }
    }
}