
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace ChestSystem.UI
{
    public class PlayerUIView : MonoBehaviour
    {
        [SerializeField] private Button buttonGetChest;
        [SerializeField] private TMP_Text textGold;
        [SerializeField] private TMP_Text textGems;
        [SerializeField] private TMP_Text textMessage;
        [SerializeField] private GameObject messageBox;
        private PlayerUIController chestUIController;

        private void Start()
        {
            buttonGetChest.onClick.AddListener(OnClickGetChest);
        }

        private void OnClickGetChest()
        {
            chestUIController.GetChest();
        }
        public void SetParent(GameObject parent)
        {
            if (parent != null)
            {
                gameObject.transform.SetParent(parent.transform, false);
            }

        }
        public void SetController(PlayerUIController controller)
        {
            chestUIController = controller;
        }
        public void SetGoldText(string text)
        {
            textGold.text = text;
        }
        public void SetGemText(string text)
        {
            textGems.text = text;
        }
        public void SetMessageText(string text)
        {
            textMessage.text = text;
            StartCoroutine(ShowForSeconds(1f));
        }
        private IEnumerator ShowForSeconds(float sec)
        {
            messageBox.SetActive(true);
            yield return new WaitForSeconds(sec);
            messageBox.SetActive(false);
        }
    }
}