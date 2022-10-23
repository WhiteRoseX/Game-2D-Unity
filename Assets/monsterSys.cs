using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSys : MonoBehaviour
{
    public GameObject canvas;
    public GameObject Player; 
    public Animator animator;
    public bool isKilling = false;
    private int state = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (Player.transform.position.x - 7f, -1.5f, -1f);
        if(isKilling){
            killPlayer();
        }
    }

    public void GoFurther(){
        state --;
        animator.SetInteger("state", state);
    }
    public void GoCloser(){
        state ++;
        animator.SetInteger("state", state);
    }

    void killPlayer(){
        canvas.GetComponent<canvas_manager>().GameOver();
    }
}
