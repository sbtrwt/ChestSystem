using ChestSystem.UI;
using ChestSystem.Chest;
namespace ChestSystem.Main
{
    public class ServiceLocator
    {
        private ChestService chestService;
        private UIService uiService;
        public ServiceLocator(ServiceLocatorModel model)
        {
            uiService = new UIService(model.UIModel);
            chestService = new ChestService(model.ChestModel);
        }
        private void InitializeServices(ServiceLocatorModel data)
        { }
        private void InjectDependencies()
        { }
        public void Start()
        {

        }
        public void Update()
        {

        }
    }
}
