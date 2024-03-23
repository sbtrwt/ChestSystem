using ChestSystem.Chest;
using ChestSystem.Event;
using UnityEngine;


namespace ChestSystem.UI
{
    public class PlayerUIController
    {
        private PlayerUIView playerUIView;
        private UIModel uiModel;
        private EventService eventService;
        private ChestService chestService;
        public PlayerUIController(UIModel model, EventService eventService, ChestService chestService)
        {
            this.eventService = eventService;
            this.chestService = chestService;
            uiModel = model;
            InitView();
            if (model?.Parent)
                SetParent(model.Parent);

           
        }
        public void InitView()
        {
            playerUIView = Object.Instantiate(uiModel.PlayerUIView);
            playerUIView.SetController(this);
        }

        public void SetParent(GameObject parent)
        {
            uiModel.Parent = parent;
            playerUIView.SetParent(parent);
        }
        public void GetChest()
        {
                       chestService.SpawnChest();
        }
        public void SetGoldText(string text)
        {
            playerUIView.SetGoldText(text);
        }
        public void SetGemText(string text)
        {
            playerUIView.SetGemText(text);
        }
    }
}
