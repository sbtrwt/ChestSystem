using ChestSystem.Chest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    private ChestController chestController;
    [SerializeField]private GameObject emptySlot;
    [SerializeField]private GameObject chestSlot;
    [SerializeField]private Button buttonChest;
    private void Start()
    {
        buttonChest.onClick.AddListener(OnClickChestButton);
    }
    public void SetController(ChestController controller)
    {
        chestController = controller;
    }
    public void SetParent(GameObject parent)
    {
        if (parent != null)
        {
            gameObject.transform.SetParent(parent.transform, false);
        }

    }
    public void ShowEmptySlot(bool isShow)
    {
        emptySlot.SetActive(isShow);
    }
    public void ShowChestSlot(bool isShow)
    {
        chestSlot.SetActive(isShow);
    }
    public void OnClickChestButton() 
    {
        Debug.Log("Chest button click");
    }
}
