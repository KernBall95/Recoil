using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float timeToDeath;

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }


    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeToDeath);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null)
        {
            if(other.gameObject.tag == "Enemy")
            {
                GameManager.Instance.GivePlayerAmmo();
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
            
    }
}
