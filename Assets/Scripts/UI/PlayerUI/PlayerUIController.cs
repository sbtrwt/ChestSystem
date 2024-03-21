﻿using ChestSystem.Event;
using UnityEngine;


namespace ChestSystem.UI
{
    public class PlayerUIController
    {
        private PlayerUIView chestUIView;
        private UIModel uiModel;
        private EventService eventService;
        public PlayerUIController(UIModel model, EventService eventService)
        {
            this.eventService = eventService;
            uiModel = model;
            InitView();
            if (model?.Parent)
                SetParent(model.Parent);

           
        }
        public void InitView()
        {
            chestUIView = Object.Instantiate(uiModel.PlayerUIView);
            chestUIView.SetController(this);
        }

        public void SetParent(GameObject parent)
        {
            uiModel.Parent = parent;
            chestUIView.SetParent(parent);
        }
        public void GetChest()
        {
            Debug.Log("create chest");

        }
    }
}
