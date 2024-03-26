using ChestSystem.UI;
using ChestSystem.Chest;
using ChestSystem.Event;

namespace ChestSystem.Main
{
    public class ServiceLocator
    {
        private ChestService chestService;
        private UIService uiService;
        private EventService eventService;
        private PlayerService playerService;
        public ServiceLocator(ServiceLocatorModel model)
        {
            InitializeServices(model);
            InjectDependencies();
        }
        private void InitializeServices(ServiceLocatorModel model)
        {
            uiService = new UIService(model.UIModel);
            chestService = new ChestService(model.ChestModel);
            eventService = new EventService();
            playerService = new PlayerService();
        }
        private void InjectDependencies()
        {
            uiService.InjectDependencies(eventService, chestService);
            playerService.InjectDependencies(uiService);
            chestService.InjectDependencies(eventService, playerService, uiService);
        }
        public void Start()
        {

        }
        public void Update()
        {

        }
    }
}
