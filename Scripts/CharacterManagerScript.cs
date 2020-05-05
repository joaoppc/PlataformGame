using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterManagerScript : MonoBehaviour
{
    
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private LayerMask plataformLayerMask;
    
    public GameObject player;
    private bool dir = true;
    
           
    
    
    

    public void Move(GameObject gameObject,float movimento) {
        gameObject.transform.position += Vector3.right *movimento * Time.fixedDeltaTime;
        if (movimento > 0 && !dir)
			{
				
				Flip();
			}
			
			else if (movimento < 0 && dir)
			{
				Flip();
			}
    
    }

    public void Respawn(GameObject gameobject)
    {   
        
        gameobject.transform.position = new Vector3(-35.75f,10f,0f);
    }

    public bool IsGrounded(BoxCollider2D boxColider) 
    {
    
       return Physics2D.Raycast(boxColider.bounds.center,Vector2.down,boxColider.bounds.extents.y +0.1f,groundLayerMask);

    }
    public bool IsOnPlataform(BoxCollider2D boxColider)
    {   

        
        
        return Physics2D.Raycast(boxColider.bounds.center,Vector2.down,boxColider.bounds.extents.y +0.1f,plataformLayerMask);
        
    }
    

    public void StickPlataform(bool isOnPlataform){
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, -Vector2.up, 4f, plataformLayerMask);
        if (isOnPlataform)
        {
            player.transform.SetParent(hit.transform);
        }
    }

    

    private void Flip()
	{
		
		dir = !dir;

		
		Vector3 scale = player.transform.localScale;
		scale.x *= -1;
		player.transform.localScale = scale;
	}

     

}
