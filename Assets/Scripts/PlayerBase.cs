using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public float shootForce;
    public float bulletForce;
    public Rigidbody2D projectile;
    public Transform projectileSpawnPos;
    public int ammoCount;
    [HideInInspector] public int shotsFired = 0;

    [HideInInspector] public Rigidbody2D rb;

    private Vector3 dir;
    private GameManager gm;

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

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameManager.Instance;
    }

    void Update()
    {
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);//Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetButtonDown("Fire1") && ammoCount > 0)
            Shoot();
    }
    void Shoot()
    {
        shotsFired++;

        if (rb.gravityScale == 0f)
            rb.gravityScale = 0.75f;

        Rigidbody2D bulletClone = Instantiate(projectile, projectileSpawnPos.position, Quaternion.identity);
        bulletClone.AddForce(bulletForce * dir.normalized, ForceMode2D.Impulse);
        
        rb.velocity = Vector3.zero;
        rb.AddForce(-bulletClone.velocity.normalized * shootForce, ForceMode2D.Impulse);
        ammoCount--;

        gm.GetComponent<AudioSource>().clip = gm.shootAudio;
        gm.GetComponent<AudioSource>().Play();
    }
}
