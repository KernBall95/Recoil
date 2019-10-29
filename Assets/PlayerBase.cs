using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public float shootForce;
    public float bulletForce;
    public Rigidbody2D projectile;
    public Transform projectileSpawnPos;

    [HideInInspector] public Rigidbody2D rb;

    private Vector3 dir;

    private static PlayerBase instance;
    public static PlayerBase Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<PlayerBase>();
            return instance;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);//Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }
    void Shoot()
    {
        if (rb.gravityScale == 0f)
            rb.gravityScale = 0.75f;

        Rigidbody2D bulletClone = Instantiate(projectile, projectileSpawnPos.position, Quaternion.identity);
        bulletClone.AddForce(bulletForce * dir.normalized, ForceMode2D.Impulse);
        
        rb.velocity = Vector3.zero;
        rb.AddForce(-bulletClone.velocity.normalized * shootForce, ForceMode2D.Impulse);
    }
}
