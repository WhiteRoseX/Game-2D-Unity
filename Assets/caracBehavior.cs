using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vitesse;
    public float maxJump;
    public float VulnerabilityTime;
    private bool isGrounded = false;
    public AudioSource jumpSound ;

    // Start is called before the first frame update
    void Start()
    {
        SetVolicity(vitesse, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && isGrounded){
            Jump();
            jumpSound.Play();
        }
    }

    void Jump()
    {   
        rb.velocity += new Vector2(0, maxJump);
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.CompareTag("Ground"))
        {
           isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.CompareTag("Ground"))
        {
           isGrounded = false;
        }
    }

    void SetVolicity(float xVelocity, float yVelocity){
        rb.velocity = new Vector2(0,0);
        rb.velocity += new Vector2(xVelocity,yVelocity);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(ObstacleFind());
        }
    }   

    IEnumerator ObstacleFind(){
        yield return new WaitForSeconds (0.1f);
        GameObject.FindWithTag("monster").GetComponent<monsterSys>().GoCloser();
        SetVolicity(vitesse/2,0);
        yield return new WaitForSeconds (0.5f);
        SetVolicity(vitesse,0);
        yield return new WaitForSeconds (VulnerabilityTime);
        GameObject.FindWithTag("monster").GetComponent<monsterSys>().GoFurther();
    }
}
