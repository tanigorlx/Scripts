//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs

using RBot;

public class CapeOfAwe
{
    public ScriptInterface Bot => ScriptInterface.Instance;

    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();
    public CoreDailys Dailys = new CoreDailys();
    

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();
        Core.AddDrop("Legendary Awe Pass", "Cape Shard", "Cape Fragment", "Cape Relic", "Cape of Awe", "Guardian Awe Pass", "Armor of Awe Pass");
        GetCoA();
        Core.SetOptions(false);
    }

    public void GetCoA()
    {
        if(Core.IsMember)
            LegendaryAwe();
        else if(GuardianCheck())
            GuardianAwe();
            else FreeAwe();
    }

    public void LegendaryAwe()
    {
        while (!Bot.ShouldExit())
        {
            if (Core.CheckInventory("Cape Relic"))
            {
                Core.Logger("Buying Cape of Awe");
                Core.BuyItem("museum", 1129, "Cape of Awe");
                break;
            }
            if (Core.CheckInventory("Cape Fragment"))
            {
                Core.Logger("Buying Cape Relic");
                Core.BuyItem("museum", 1129, "Cape Relic");
            }
            if (!Core.CheckInventory("Legendary Awe Pass", 1, true))
            {
                Core.Logger("Buying Legendary Awe Pass");
                Core.BuyItem("museum", 1130, "Legendary Awe Pass");
            }
            Core.Logger("Farming Cape Shard");
            Core.EnsureAccept(4178);
            Core.EquipClass(ClassType.Solo);
            Core.KillMonster("doomvault", "r5", "Left", 1215, "Cape Shard", 1, false);
            Core.EnsureComplete(4178);
        }
        Core.StopBot();
    }
    
    public bool GuardianCheck()
    {
        Core.Logger("Checking AQ Guardian");
        if (Core.CheckInventory("Guardian Awe Pass", 1, true))
        {
            Core.Logger("You're AQ Guardian!");
            return true;
        }
        Core.BuyItem("museum", 53, "Guardian Awe Pass");
        if (Core.CheckInventory("Guardian Awe Pass"))
        {
            Core.Logger("Guardian Awe Pass bought successfully!");
            Core.Logger("You're AQ Guardian!");
            return true;
        }
        else
            Core.Logger("You're not AQ Guardian.");
            return false;
    }
    public void GuardianAwe()
    {
        while (!Bot.ShouldExit())
        {
            if (Core.CheckInventory("Cape Relic"))
            {
                Core.Logger("Buying Cape of Awe");
                Core.BuyItem("museum", 1129, "Cape of Awe");
                break;
            }
            if (Core.CheckInventory("Cape Fragment"))
            {
                Core.Logger("Buying Cape Relic");
                Core.BuyItem("museum", 1129, "Cape Relic");
            }
            if (Bot.Player.Level < 35)
            {
                Core.Logger("Farming XP");
                Farm.Experience(35);
            }
            if(Bot.Player.GetFactionRank("Blade of Awe") < 5)
            {
                Core.Logger("Farming Blade of Awe Rep");
                Farm.BladeofAweREP(5, false);
            }
            Core.Logger("Farming Cape Shard");
            Core.EnsureAccept(4179);
            Core.EquipClass(ClassType.Solo);
            Core.KillMonster("doomvault", "r5", "Left", 1215, "Cape Shard", 1, false);
            Core.EnsureComplete(4179);            
        }
        Core.StopBot();
    }
    public void FreeAwe()
    {
        while(!Bot.ShouldExit())
        {
            if (Core.CheckInventory("Cape Relic"))
            {
                Core.Logger("Buying Cape of Awe");
                Core.BuyItem("museum", 1129, "Cape of Awe");
                break;
            }
            if (Core.CheckInventory("Cape Fragment"))
            {
                Core.Logger("Buying Cape Relic");
                Core.BuyItem("museum", 1129, "Cape Relic");
            }
             if (Bot.Player.Level < 55)
            {
                Core.Logger("Farming XP");
                Farm.Experience(55);
            }
            if(Bot.Player.GetFactionRank("Blade of Awe") < 10)
            {
                Core.Logger("Farming Blade of Awe Rep");
                Farm.BladeofAweREP(10, false);
            }
            if(!Core.CheckInventory("Armor of Awe Pass", 1, true))
            {
                Core.Logger("Buying Armor of Awe Pass");
                Core.BuyItem("museum", 1130, "Armor of Awe Pass");
            }
            Core.Logger("Farming Cape Shard");
            Core.EnsureAccept(4180);
            Core.EquipClass(ClassType.Solo);
            Core.KillMonster("doomvault", "r5", "Left", 1215, "Cape Shard", 1, false);
            Core.EnsureComplete(4180);      
        }
        Core.StopBot();
    }
}