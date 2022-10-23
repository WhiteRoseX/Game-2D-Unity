using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour
{
    public Animator animator;
    public AudioClip saw;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource> ().playOnAwake = false;
        GetComponent<AudioSource> ().clip = saw;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isCollected", true);
        }   
         GetComponent<AudioSource> ().Play ();
    }
}
