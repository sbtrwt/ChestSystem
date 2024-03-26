using ChestSystem.Event;
using ChestSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestSystem.Chest
{
    public class ChestPool : GenericObjectPool<ChestController>
    {
        private ChestModel chestModel;
        private EventService eventService;
        private ChestService chestService;
        public ChestPool(ChestModel model, EventService eventService, ChestService chestService)
        {
            this.chestModel = model;
            this.eventService = eventService;
            this.chestService = chestService;
        }

        public ChestController GetChest() {
            if (GetUnusedItemCount<ChestController>() > 0)
            {
                return GetItem<ChestController>();
            }
            else
            {
                return null;
            }
        }

        protected override ChestController CreateItem<T>() => new ChestController(chestModel, eventService, chestService);

        public List<ChestController> InitChestPoolItems(int quantity)
        {
            List<ChestController> chestControllerList = new List<ChestController>();
            for (int i = 0; i < quantity; i++)
            {
                chestControllerList.Add(GetItem<ChestController>());
            }
            return chestControllerList;
        }
    }
}
