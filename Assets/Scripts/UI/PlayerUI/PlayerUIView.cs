
using UnityEngine;
using UnityEngine.UI;
namespace ChestSystem.UI
{
    public class PlayerUIView : MonoBehaviour
    {
        [SerializeField] private Button buttonGetChest;
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
    }
}