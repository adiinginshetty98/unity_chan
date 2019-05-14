using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;

    private float hor;
    private float ver;
    private bool run;

    public AudioSource damagesound;
    public AudioSource laughter;
    
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        run = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))               //for standing animations
        {
            anim.Play("WAIT01", -1, 0f);
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("WAIT02", -1, 0f);
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("WAIT03", -1, 0f);
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("WAIT04", -1, 0f);
            laughter.Play();
        }
        if (Input.GetKeyDown("0"))
        {
            anim.Play("WAIT00", -1, 0.5f);
        }

        if(Input.GetMouseButtonDown(0))     //for damage animation.also sound.
        {
            anim.Play("DAMAGED00", -1, 0f);
            damagesound.Play();
        }

        hor = Input.GetAxis("Horizontal"); 
        ver = Input.GetAxis("Vertical");

        anim.SetFloat("InputH", hor);       //linking variables to parameters.
        anim.SetFloat("InputV", ver);
        anim.SetBool("run", run);

        if (Input.GetKey(KeyCode.LeftShift))    //to check if shift is pressed.
        {
            run = true;
            
        }
        else
        {
            run = false;
        }
         if(Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
         else
        {
            anim.SetBool("jump", false);
        }

        float moveX = hor * 20f * Time.deltaTime;        //for movement of character.
        float moveZ = ver * 50f * Time.deltaTime;        //Time.deltatime is fo animation to take place each frame. 

        if (moveZ<=0)
        {
            moveX = 0;
        }

        if (run == true)                         //for running
        {
            moveX *= 3f;
            moveZ *= 3f;
            
        }
        rb.velocity = new Vector3(moveX, 0f, moveZ);





    }
}
