namespace Plugin_Architecture;

public interface IPlugin
{
    public string PluginName { get; init; }

    public void Invoke();
}

