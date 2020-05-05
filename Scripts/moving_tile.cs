using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_tile : MonoBehaviour
{

    bool moveRight = true;
    float direction,speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -6f)
        {
            moveRight = false;
        }
        if (transform.position.x > 1f)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        
        }
    }
}
