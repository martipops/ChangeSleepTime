using System.ComponentModel;
using Terraria.ModLoader.Config;

public class Config : ModConfig
{
	[DefaultValue(5)]
	[Range(0, 100)]
	public int SleepTimeMultiplier;

	public override ConfigScope Mode => ConfigScope.ServerSide;

	public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
	{
		message = "Cannot modify config whilst in a server!";
		return false;
	}
}
