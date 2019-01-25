using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    CharacterController charController;

    [SerializeField] float jumpSpeed = 20.0f;

    [SerializeField] float gravity = 1.0f;
    float yVelocity = 0.0f;

    [SerializeField] float moveSpeed = 5.0f;
    public float h;
    public float v;
    Animator anim;

    [SerializeField] GameObject Cam;

    AudioSource audioSource;

    [SerializeField] AudioClip runClip;

    public float runSpeed;

    bool running;

	// Use this for initialization
	void Start () {
        charController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        

        runSpeed = charController.velocity.magnitude;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);

        Vector3 direction = new Vector3(h, 0, v);
        Vector3 velocity = direction * moveSpeed;

        

        if(charController.isGrounded)
        {
            if(Input.GetButton("Jump"))
            {
                anim.SetTrigger("Jump");
                yVelocity = jumpSpeed;
            }
           
        }
        else
        {
            yVelocity -= gravity;
        }
        velocity.y = yVelocity;

        velocity = transform.TransformDirection(velocity);

        charController.Move(velocity * Time.deltaTime);

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0) {
            
            running = true;
            
        }
        else {
            running = false;
        }

        if (running == true) {

            if (!audioSource.isPlaying) 
            {
             audioSource.clip = runClip;

            audioSource.Play();
            }
            
        }
       
       if (running = false) {
           audioSource.Stop();

           
       }

    }


}

