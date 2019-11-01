using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameManager gm;

    void Awake()
    {
        gm = GameManager.Instance; 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gm.levelComplete = true;
            gm.GetComponent<AudioSource>().clip = gm.goalReachedAudio;
            gm.GetComponent<AudioSource>().Play();
        }
            
    }
}
