using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyBase : MonoBehaviour
{
    public Transform patrol1, patrol2;
    public float moveSpeed;

    private Vector2 startingPoint;
    private int movingTo;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = (patrol1.position + patrol2.position) / 2;
        transform.position = startingPoint;
        movingTo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingTo == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrol1.position, Time.deltaTime * moveSpeed);
            if (transform.position == patrol1.position)
                movingTo = 2;
        }
        else if(movingTo == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrol2.position, Time.deltaTime * moveSpeed);
            if (transform.position == patrol2.position)
                movingTo = 1;
        }
    }
}
