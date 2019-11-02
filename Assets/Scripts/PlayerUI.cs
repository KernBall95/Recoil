using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Text currentShotsText;
    [SerializeField] private Text minShotsText;
    [SerializeField] private Text currentAmmoText;
    public int minShotAmount;
    [HideInInspector] public int currentShotAmount;
    [HideInInspector] public int currentAmmoAmount;
    
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

            if(currentAmmoAmount != PlayerBase.Instance.ammoCount)
            {
                currentAmmoAmount = PlayerBase.Instance.ammoCount;
                UpdateCurrentAmmoAmount();
            }
        }       
    }

    void UpdateShotsFiredText()
    {
        currentShotsText.text = "Shots fired: " + currentShotAmount;
    }

    void UpdateCurrentAmmoAmount()
    {
        currentAmmoText.text = "Ammo remaining: " + currentAmmoAmount;
    }

    void InitializeUI()
    {
        currentShotAmount = 0;
        currentAmmoAmount = PlayerBase.Instance.ammoCount;

        currentShotsText.text = "Shots fired: " + 0;
        minShotsText.text = "Minimum shots: " + minShotAmount;
        currentAmmoText.text = "Ammo remaining: " + currentAmmoAmount;
    }
}
