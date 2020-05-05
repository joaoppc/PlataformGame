using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManagerScript : MonoBehaviour
{

    public static ScoreManagerScript instance;
    public TextMeshProUGUI textCherry;
    int score; 
    public int life; 
    public TextMeshProUGUI textLife;
    
    // Start is called before the first frame update
    void Start()
    {   
        
        
        textLife.text = string.Format("Life: {0}",GameState.life);
        textCherry.text = string.Format("x{0}",GameState.score);
        if(instance == null)
        {
            instance = this;
        }

    }

    // Update is called once per frame
    public void ChangeScore()
    {
        
        GameState.score+=1;
        textCherry.text = string.Format("x{0}",GameState.score);
        
    }
    public void LoseLife()
    {
        
        GameState.life-=1;
        textLife.text = string.Format("Life: {0}",GameState.life);
        
    }
}
