using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

public class AdjustTimeRate : ModSystem
{
	private static readonly Config config = ModContent.GetInstance<Config>();
    

    public override void ModifyTimeRate(ref double timeRate, ref double tileUpdateRate, ref double eventUpdateRate)
    {
        // Original Author: Aberranthian
        int targetTimeRate = CreativePowerManager.Instance.GetPower<CreativePowers.ModifyTimeRate>().TargetTimeRate;
        bool isEveryoneSleeping = Main.CurrentFrameFlags.SleepingPlayersCount > 0 && Main.CurrentFrameFlags.SleepingPlayersCount == Main.CurrentFrameFlags.ActivePlayersCount;
        int currentTimeRate = targetTimeRate;
        if (!Main.gameMenu && isEveryoneSleeping)
        {
            currentTimeRate *= config.SleepTimeMultiplier;
        }
        if (CreativePowerManager.Instance.GetPower<CreativePowers.FreezeTime>().Enabled)
        {
            currentTimeRate = 0;
        }
        timeRate = currentTimeRate;
        tileUpdateRate = currentTimeRate;
        eventUpdateRate = currentTimeRate;
        if (Main.gameMenu)
        {
            timeRate = 1.0;
            tileUpdateRate = 1.0;
            eventUpdateRate  = 1.0;
        }
        base.ModifyTimeRate(ref timeRate, ref tileUpdateRate, ref eventUpdateRate);
        if (timeRate > 86400.0)
        {
            timeRate = 86400.0;
        }
    }
}
