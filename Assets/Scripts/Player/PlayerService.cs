using ChestSystem.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService
{
    private int gold;
    private int gems;
    private UIService uiService;
    public PlayerService() { }

    public void InjectDependencies(UIService uiService)
    {
        this.uiService = uiService;
    }

    public void AddGold(int gold)
    {
        this.gold += gold;
        uiService.SetGoldText(this.gold.ToString());
    }
    public void AddGem(int gem)
    {
        this.gems += gem;
        uiService.SetGemText(gems.ToString());
    }

}
