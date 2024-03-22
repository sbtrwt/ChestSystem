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
        private int chestPoolSize = 8;
        public ChestService(ChestModel model)
        {
            this.chestModel = model;
            //chestController = new ChestController(uiModel, eventService);
            chestPool = new ChestPool(model);
            InitChestList();
        }
        public void InjectDependencies(EventService eventService)
        {
            this.eventService = eventService;
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
