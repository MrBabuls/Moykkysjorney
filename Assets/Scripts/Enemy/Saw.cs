using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed = 2;
    public Transform rightCheck;
    public Transform leftCheck;
    
    private int dir = 1;

   
    void Update()
    {
        transform.Translate(Vector2.right * speed * dir * Time.deltaTime);
        if (Physics2D.Raycast(rightCheck.position, Vector2.down, 2) == false)
            dir = -1;

        transform.Translate(Vector2.right * speed * dir * Time.deltaTime);
        if (Physics2D.Raycast(leftCheck.position, Vector2.down, 2) == false)
            dir = 1;
    }
}
