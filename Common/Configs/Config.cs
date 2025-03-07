using System.ComponentModel;
using Terraria.ModLoader.Config;

public class Config : ModConfig
{
	[DefaultValue(5)]
	[Range(0, 100)]
	public int SleepTimeMultiplier;

	public override ConfigScope Mode => ConfigScope.ServerSide;
}
