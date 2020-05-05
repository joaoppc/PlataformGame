using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{

    public CharacterManagerScript controller;
    bool pulo = false;
    float speed = 15f;
    float jumpforce = 1500f;
    Rigidbody2D  char_rigidbody;
    BoxCollider2D char_boxColider;
    public Animator animator;
    //[SerializeField] private LayerMask groundLayerMask;
    ScoreManagerScript scoreController;
    public GameObject gameover;
    public GameObject Winner;
    
    
    

    float moveHorizontal = 0f;
    // Start is called before the first frame update
    void Start()

    {
        
        char_rigidbody = GetComponent<Rigidbody2D>();
        char_rigidbody.freezeRotation = true;
        char_boxColider = GetComponent<BoxCollider2D>();
        
        
        
    }


    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed",Mathf.Abs(moveHorizontal));

		if (Input.GetButtonDown("Jump") )
		{
			pulo = true;
		}
    }
    public void aterrisa()
    {
        animator.SetBool("Jump",false);
    }

    void  FixedUpdate() {
        
        //gameObject.transform.position += Vector3.right *moveHorizontal * Time.fixedDeltaTime;
        controller.Move(gameObject,moveHorizontal);

        if(pulo && controller.IsGrounded(char_boxColider) || pulo && controller.IsOnPlataform(char_boxColider))
        {   
            sound_manager_script.PlaySound("jump");
            animator.SetBool("Jump",pulo);
            pulo = false;
            char_rigidbody.AddForce(new Vector2(0f, jumpforce));
        }
        else if(controller.IsGrounded(char_boxColider) || controller.IsOnPlataform(char_boxColider))
        {
            animator.SetBool("Jump",false);
            animator.SetBool("Dano",false); 
        }
        if(GameState.life == 0)
        {
            Destroy(GameObject.FindGameObjectsWithTag("BackgroundMusic")[0]);
            gameover.SetActive(true);
            StartCoroutine(Timer());
            
            
        }else if(GameState.score == 13){
            Destroy(GameObject.FindGameObjectsWithTag("BackgroundMusic")[0]);
            Winner.SetActive(true);
            StartCoroutine(Timer());
        }
        if (controller.IsOnPlataform(char_boxColider))
        {   
            controller.StickPlataform(controller.IsOnPlataform(char_boxColider));
        }else{
            transform.SetParent(null);
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Cherry")
        {
            Destroy(other.gameObject);
            ScoreManagerScript.instance.ChangeScore();
        }
        else if(other.tag == "Checkpoint" )
        {
            SceneManager.LoadScene(2);
        }
        else if(other.tag == "enemy")
        {
            ScoreManagerScript.instance.LoseLife();
            animator.SetBool("Dano",true); 
            char_rigidbody.AddForce(new Vector2(0f, jumpforce));
            controller.Respawn(gameObject);
                   
        }
        //else if(other.tag == "Fall")
        //{
        //    controller.Respawn(gameObject);
        //    animator.SetBool("Dano",true); 
        //    char_rigidbody.AddForce(new Vector2(0f, jumpforce));
        //    ScoreManagerScript.instance.LoseLife();
        //}
    }
    IEnumerator Timer() {
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
        
    } 
}
