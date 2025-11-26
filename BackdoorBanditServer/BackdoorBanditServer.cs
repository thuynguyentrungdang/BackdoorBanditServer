using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using BackdoorBanditServer.Models;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Models.Utils;
using Range = SemanticVersioning.Range;

namespace BackdoorBanditServer;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.raitheraichu.backdoorbanditserver";
    public override string Name { get; init; } = "Backdoor Bandit Server";
    public override string Author { get; init; } = "RaiRaiTheRaichu";
    public override SemanticVersioning.Version Version { get; init; } = new("2.0.3");
    public override Range SptVersion { get; init; } = new("~4.0.0");
    public override string License { get; init; } = "MIT";
    public override bool? IsBundleMod { get; init; } = true;
    public override Dictionary<string, Range>? ModDependencies { get; init; } = new()
    {
        { "com.wtt.commonlib", new Range("~2.0.0") }
    };
    public override string? Url { get; init; }
    public override List<string>? Contributors { get; init; }
    public override List<string>? Incompatibilities { get; init; }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 2)]
public class BackdoorBanditServer (
    ISptLogger<BackdoorBanditServer> logger,
    ModHelper modHelper,
    CustomStaticRouter customStaticRouter,
    WTTServerCommonLib.WTTServerCommonLib wttCommon) : IOnLoad
{
    private ModConfig? _modConfig;
    
	public async Task OnLoad()
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