using ChestSystem.Event;
using ChestSystem.Main;
using ChestSystem.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ChestSystem.Chest
{
    public class ChestService
    {
        private ChestPool chestPool;
        private ChestModel chestModel;
        private EventService eventService;
        private List<ChestController> chestControllerList;
        private ChestActionController chestActionController;
        private int chestPoolSize = 8;
        private int unlockingChestCount = 1;
        private UIService uiService;

        public int UnlockingChestCount { get {return unlockingChestCount; } }
        public ChestService(ChestModel model)
        {
            this.chestModel = model;
        }
        public void InjectDependencies(EventService eventService, PlayerService playerService, UIService uIService)
        {
            this.eventService = eventService;
            this.uiService = uIService;
            chestPool = new ChestPool(chestModel, eventService);
            InitChestList();
            chestActionController = new ChestActionController(chestModel.ChestActionModel, eventService, this, playerService, uiService);
        }
        public void SpawnChest()
        {
            ChestController spawnedChest = chestPool.GetChest();
            if (spawnedChest != null)
            {
                spawnedChest.SetChest();
            }
            else
            {
                uiService.SetMessageText(GlobalConstant.TEXT_FULLSLOTS);
            }
        }
        public void InitChestList()
        {
            chestControllerList = chestPool.InitChestPoolItems(chestPoolSize);
            foreach (var chestContorller in chestControllerList)
            {
                chestPool.ReturnItem(chestContorller);
            }
        }
        public void ReturnChestToPool(ChestController chestToReturn)
        {
            chestPool.ReturnItem(chestToReturn);
            chestToReturn.ResetChest();
        }
    }
}
