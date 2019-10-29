using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSelfDestruct : MonoBehaviour
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
            Destroy(gameObject);
    }
}
