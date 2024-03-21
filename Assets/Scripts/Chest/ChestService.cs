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
        private ChestController chestController;
        public ChestService(ChestModel model)
        {
            this.chestModel = model;
            //chestController = new ChestController(uiModel, eventService);
            chestPool = new ChestPool(model);
        }
        public void InjectDependencies(EventService eventService)
        {
            this.eventService = eventService;
        }


    }
}
