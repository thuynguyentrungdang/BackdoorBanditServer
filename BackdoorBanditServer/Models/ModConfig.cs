using System.Text.Json.Serialization;

namespace BackdoorBanditServer.Models;

public class ModConfig
{
    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }
    [JsonPropertyName("shotgunList")]
    public required List<string> ShotgunList { get; set; }
    [JsonPropertyName("grenadeLauncherList")]
    public required List<string> GrenadeLauncherList { get; set; }
    [JsonPropertyName("meleeWeaponList")]
    public required List<string> MeleeWeaponList { get; set; }
    [JsonPropertyName("otherWeaponList")]
    public required List<string> OtherWeaponList { get; set; }
    [JsonPropertyName("blacklistedRooms")]
    public required List<string> BlacklistedRooms { get; set; }
    [JsonPropertyName("whitelistedRounds")]
    public required List<string> WhitelistedRounds { get; set; }
}