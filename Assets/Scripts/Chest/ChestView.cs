using ChestSystem.Chest;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    private ChestController chestController;
    [SerializeField] private GameObject emptySlot;
    [SerializeField] private GameObject chestSlot;
    [SerializeField] private Button buttonChest;
    [SerializeField] private TMP_Text textTimer;
    [SerializeField] private TMP_Text textStatus;
    [SerializeField] private TMP_Text textGem;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Color backgroundColor;
    [SerializeField] private Color backgroundOpenColor;
    [SerializeField] private GameObject gemSlot;
    private void Start()
    {
        buttonChest.onClick.AddListener(OnClickChestButton);
        backgroundImage.color = backgroundColor;
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
        chestController?.UpdateChest();
    }
    public void SetDefaultBackground() { backgroundImage.color = backgroundColor; }
    public void SetOpenBackground() { backgroundImage.color = backgroundOpenColor; }
    public void ShowGemSlot(bool isShow)
    {
        gemSlot.SetActive(isShow);
    }
}
