
using ChestSystem.Chest;
using ChestSystem.Event;
using UnityEngine;
namespace ChestSystem.UI
{
    public class UIService  
    {
       
        private UIModel uiModel;
        private EventService eventService;
        private PlayerUIController playerUIController;
        private ChestService chestService;
        public UIService(UIModel uiModel)
        {
            this.uiModel = uiModel;
          
        }
        public void InjectDependencies(EventService eventService, ChestService chestService)
        {
            this.eventService = eventService;
            this.chestService = chestService;
            playerUIController = new PlayerUIController(uiModel, eventService, chestService);
        }
       
    }
}