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
        public EventService()
        {
            OnChestSlotClick = new EventController<ChestSO>();
        }
    }
}
