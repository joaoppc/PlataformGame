using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpssumScript : MonoBehaviour
{
    bool moveRight = true;
    float direction,speed = 3f;
    private bool dir = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 6f)
        {
            moveRight = false;
        }
        if (transform.position.x > 20f)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            if (!dir){
                Flip();
            }
        }
        else
        {
            
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            if(dir)
            {
                Flip();
            }
        }
        // if (movimento > 0 && !dir)
		// 	{
				
		// 		Flip();
		// 	}
			
		// 	else if (movimento < 0 && dir)
		// 	{
		// 		Flip();
		// 	}

        void Flip()
	{
		
		dir = !dir;

		
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
    }
}
