//Initial Setup
var pluginsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Plugins";
Dictionary<string, IPlugin> registry = new();

//Loading plugins
LoadPlugins(pluginsPath, registry);

//Printing MainMenu
PrintMenu(registry);

//Getting & Handling input
HandleInput(Console.ReadLine(), pluginsPath, registry);



//LoadPlugins routine
static void LoadPlugins(string path, Dictionary<string, IPlugin> registry)
{
    if (Directory.Exists(path) is false) { Directory.CreateDirectory(path); return; }
    registry.Clear();

    Directory.GetFiles(path,"*.dll").ToList().ForEach(dll =>
    {
        AssemblyLoadContext assemblyLoadContext = new(Path.GetFileNameWithoutExtension(dll));
        Assembly assembly = assemblyLoadContext.LoadFromAssemblyPath(dll);
        assembly.GetTypes().ToList().ForEach(type =>
        {
            if(typeof(IPlugin).IsAssignableFrom(type)){
                var plugin = (Activator.CreateInstance(type)) as IPlugin;
                if(plugin is not null)
                    registry.Add(type.Name, plugin);
            }
        });
    });
}

//Mainmenu routine
static void PrintMenu(Dictionary<string, IPlugin> registry)
{
    Console.WriteLine("Welcome to Plugin Architecture\n\n\tWrite a plugin name from list below to Invoke it");
    registry.Keys.ToList().ForEach(Console.WriteLine);
    Console.WriteLine("\nWrite -R to reload plugins!");
}

void HandleInput(string? input, string path, Dictionary<string, IPlugin> registry)
{
    if (input is null) HandleInput(Console.ReadLine(), path, registry);

    if (input?.Equals("-r") ?? false)
    {
        LoadPlugins(path, registry);
        PrintMenu(registry);
        HandleInput(Console.ReadLine(),path,registry);
        return;
    }

    registry.Keys.ToList().ForEach(key=>
    {
        if(input?.Equals(key.ToLower()) is true){
            registry[key].Invoke();            
            Console.ReadLine();
        }
    });

    PrintMenu(registry);
    HandleInput(Console.ReadLine(),path,registry);
}
