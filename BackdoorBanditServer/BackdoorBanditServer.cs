using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using BackdoorBanditServer.Models;
using SPTarkov.Common.Models.Logging;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Helpers.Server;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Models.Utils;
using Range = SemanticVersioning.Range;

namespace BackdoorBanditServer;

public record ModMetadata : IModMetadata
{
    public string ModGuid { get; init; } = "com.raitheraichu.backdoorbanditserver";
    public string Name { get; init; } = "Backdoor Bandit Server";
    public string Author { get; init; } = "RaiRaiTheRaichu";
    public SemanticVersioning.Version Version { get; init; } = new("2.0.3");
    public Range SptVersion { get; init; } = new("~4.0.0");
    public bool HasPrepatcher { get; init; }
    public string License { get; init; } = "MIT";
    public Dictionary<string, Range>? ModDependencies { get; init; } = new()
    {
        { "com.wtt.commonlib", new Range("~2.0.0") }
    };
    public string? Url { get; init; }
    public List<string>? Contributors { get; init; }
    public List<string>? Incompatibilities { get; init; }
}

[Injectable(TypePriority = OnLoadOrder.PostLoad + 2)]
public class BackdoorBanditServer (
    ISptLogger<BackdoorBanditServer> logger,
    ModHelper modHelper,
    CustomStaticRouter customStaticRouter,
    WTTServerCommonLib.WTTServerCommonLib wttCommon) : IOnLoad
{
    private ModConfig? _modConfig;
    
	public async Task OnLoadAsync(CancellationToken cancellationToken)
    {
        // Get your current assembly
        var assembly = Assembly.GetExecutingAssembly();
        var pathToMod = modHelper.GetAbsolutePathToModFolder(assembly);
        
        _modConfig = modHelper.GetJsonDataFromFile<ModConfig>(pathToMod, "config/config.json");
        
        customStaticRouter.PassConfig(_modConfig);
        
        // Use WTT-CommonLib services
        await wttCommon.CustomItemServiceExtended.CreateCustomItems(assembly);
        await wttCommon.CustomHideoutRecipeService.CreateHideoutRecipes(assembly);
        
        logger.Success("[BackdoorBanditServer] Loaded!");
        
        await Task.CompletedTask;
    }

}