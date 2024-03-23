using ChestSystem.Chest;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
    public class ChestActionView : MonoBehaviour
    {
        private ChestActionController chestActionController;
        [SerializeField] private Button startTimerButton;
        [SerializeField] private Button openNowButton;
        [SerializeField] private Button closeButton;

        private void Start()
        {
            startTimerButton.onClick.AddListener(OnClickStartTimer);
            openNowButton.onClick.AddListener(OnClickOpenNow);
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(OnClickClose);
        }
        public void SetController(ChestActionController controller)
        {
            chestActionController = controller;
        }
        public void SetParent(GameObject parent)
        {
            if (parent != null)
            {
                gameObject.transform.SetParent(parent.transform, false);
            }

        }
        private void OnClickStartTimer() { chestActionController.OnStartTimer(); }
        private void OnClickOpenNow() { chestActionController.OnOpenNow(); }

        private void OnClickClose()
        {
            chestActionController.OnClose();
        }



    }
}
