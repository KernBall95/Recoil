using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool levelComplete;
    public AudioClip shootAudio;
    public AudioClip goalReachedAudio;
    private bool winScreenShown = false;
    private PlayerUI ui;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<GameManager>();
            return instance;
        }       
    }

    void Awake()
    {
        ui = GetComponentInChildren<PlayerUI>();
    }

    void Start()
    {
        PlayerBase.Instance.rb.gravityScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if(levelComplete && !winScreenShown)
        {
            if (ui.currentShotAmount == ui.minShotAmount)
                Debug.Log("Level Complete! Perfect Run!!!");
            else
                Debug.Log("Level Complete!");

            winScreenShown = true;            
        }
    }

    public void GivePlayerAmmo()
    {
        PlayerBase.Instance.ammoCount++;
    }

    public void KillPlayer()
    {
        Destroy(PlayerBase.Instance.gameObject);
    }
}
