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
    [JsonPropertyName("plebMode")]
    public required bool PlebMode { get; set; }
    [JsonPropertyName("semiPlebMode")]
    public required bool SemiPlebMode { get; set; }
    [JsonPropertyName("breachingRoundOpensMetalDoors")]
    public required bool BreachingRoundOpensMetalDoors { get; set; }
    [JsonPropertyName("openLootableContainers")]
    public required bool OpenLootableContainers { get; set; }
    [JsonPropertyName("openCarDoors")]
    public required bool OpenCarDoors { get; set; }
    [JsonPropertyName("minHitPoints")]
    public required int MinHitPoints { get; set; }
    [JsonPropertyName("maxHitPoints")]
    public required int MaxHitPoints { get; set; }
    [JsonPropertyName("explosiveTimerInSec")]
    public required int ExplosiveTimerInSec { get; set; }
    [JsonPropertyName("explosionStats")]
    public ExplosionStats ModExplosionStats = new();
    public class ExplosionStats
    {
        [JsonPropertyName("explosionDoesDamage")]
        public bool ExplosionDoesDamage { get; set; }
        [JsonPropertyName("explosionRadius")]
        public int ExplosionRadius { get; set; }
        [JsonPropertyName("explosionDamage")]
        public int ExplosionDamage { get; set; }
    }
}