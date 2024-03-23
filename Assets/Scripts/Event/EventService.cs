using ChestSystem.Chest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestSystem.Event
{
    public class EventService
    {
        public EventController<ChestSO> OnChestSlotClick { get; private set; }
        public EventController OnStartTimer { get; private set; }
        public EventController OnOpenNow { get; private set; }
        public EventController<ChestController> OnOpenChestAction { get; private set; }
        public EventService()
        {
            OnChestSlotClick = new EventController<ChestSO>();
            OnStartTimer = new EventController();
            OnOpenNow = new EventController();
            OnOpenChestAction = new EventController<ChestController>();
        }
    }
}
