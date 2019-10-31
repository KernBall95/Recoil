using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Text currentShotsText;
    [SerializeField] private Text minShotsText;
    [HideInInspector] public int minShotAmount;
    [HideInInspector] public int currentShotAmount;
    
    void Start()
    {
        InitializeUI();
    }

    void Update()
    {
        if(PlayerBase.Instance != null)
        {
            if (currentShotAmount != PlayerBase.Instance.shotsFired)
            {
                currentShotAmount = PlayerBase.Instance.shotsFired;
                UpdateShotsFiredText();
            }
        }       
    }

    void UpdateShotsFiredText()
    {
        currentShotsText.text = "Shots fired: " + currentShotAmount;
    }

    void InitializeUI()
    {
        currentShotAmount = 0;
        currentShotsText.text = "Shots fired: " + 0;
        minShotsText.text = "Minimum shots: " + minShotAmount;
    }
}
