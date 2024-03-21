
using ChestSystem.Event;
using UnityEngine;
namespace ChestSystem.UI
{
    public class UIService  
    {
       
        private UIModel uiModel;
        private EventService eventService;
        private PlayerUIController playerUIController;
        public UIService(UIModel uiModel)
        {
            this.uiModel = uiModel;
            playerUIController = new PlayerUIController(uiModel, eventService);
        }
        public void InjectDependencies(EventService eventService)
        {
            this.eventService = eventService;
        }
       
    }
}