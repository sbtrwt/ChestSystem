using ChestSystem.Event;
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
        public ChestService(ChestModel model)
        {
            this.chestModel = model;
            //chestController = new ChestController(uiModel, eventService);
         
        }
        public void InjectDependencies(EventService eventService, PlayerService playerService)
        {
            this.eventService = eventService;
            chestPool = new ChestPool(chestModel, eventService);
            InitChestList();
            chestActionController = new ChestActionController(chestModel.ChestActionModel, eventService, this, playerService);
        }
        public void SpawnChest()
        {
            ChestController spawnedChest = chestPool.GetChest();
            if (spawnedChest != null)
            {
                spawnedChest.SetChest();
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
