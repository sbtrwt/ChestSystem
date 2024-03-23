using ChestSystem.Chest;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    private ChestController chestController;
    [SerializeField]private GameObject emptySlot;
    [SerializeField]private GameObject chestSlot;
    [SerializeField]private Button buttonChest;
    [SerializeField] private TMP_Text textTimer;
    [SerializeField] private TMP_Text textStatus;
    [SerializeField] private TMP_Text textGem;
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
        //chestController.StartChestTimer();
        chestController.OpenChestActionPanel();
    }
    public void SetTimerText(string text)
    {
        textTimer.text = text;
    }
    public void SetStatusText(string text)
    {
        textStatus.text = text;
    }
    public void SetGemText(string text)
    {
        textGem.text = text;
    }
    private void Update()
    {
        chestController.UpdateChest();
    }
}
