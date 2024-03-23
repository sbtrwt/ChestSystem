using ChestSystem.Event;
using ChestSystem.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestActionController
    {
        protected ChestActionModel chestActionModel;
        protected ChestActionView chestActionView;
        private EventService eventService;
        private ChestController chestController;
        public ChestActionController(ChestActionModel model, EventService eventService)
        {
            this.eventService = eventService;
            chestActionModel = model;
            InitView();
            if (model?.Parent)
            { SetParent(model.Parent); }

            SubscriveEvent();

        }

        private void SubscriveEvent()
        {
            eventService.OnOpenChestAction.AddListener(OnOpenChestAction);
        }
        private void InitView()
        {
            chestActionView = Object.Instantiate(chestActionModel.ChestActionPrefab);
            chestActionView.SetController(this);
        }
        public void SetParent(GameObject parent)
        {
            chestActionModel.Parent = parent;
            chestActionView.SetParent(parent);
        }
        public void ShowChestActionView(bool isShow)
        {
            chestActionView.gameObject.SetActive(isShow);
        }

        public void OnStartTimer() { chestController?.StartChestTimer(); OnClose(); }
        public void OnOpenNow() { eventService.OnOpenNow.InvokeEvent(); }
        public void OnClose()
        {
            this.chestController = null;
            ShowChestActionView(false);
        }
        public void OnOpenChestAction(ChestController chestController)
        {
            this.chestController = chestController;
            ShowChestActionView(true);
        }

        ~ChestActionController()
        {
            eventService.OnOpenChestAction.RemoveListener(OnOpenChestAction);
        }
    }
}
