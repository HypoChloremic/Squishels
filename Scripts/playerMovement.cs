using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {


    // We are writing in a script attached as a script component
    // to  our player game object

    private Rigidbody2D rb2d;
    Animator anim;

    private int mugabe = 0;
    public int forceMultiplier = 1;
    private Vector2 zeroVector = new Vector2(0, 0);

    void Start()
    {
        // this way we access the RigidBody2D object of our 
        // current gameobject we are attached to in this script
        // i.e. the player object. 
        rb2d = GetComponent<Rigidbody2D>();

        // Because the animator is part of a child GameObject, namely the 
        // Rig_purpleFighter, we have not associated the animator to the current
        // gameObject the playerMovement is associated with. Thus we need to access
        // the component in the child, therefore GetComponentInChildren. 
        anim = GetComponentInChildren<Animator>();
    }

    // we would like to check every frame for player input
    // we would also like to apply forces in accord to this input
    // there is the Update method and the FixedUpdate method.
    // Update is called before rendering every frame.
    // FixedUpdate is called just before performing any physics calculation
    // and it is here where the physics code will go. 



    // the movment of the character will occur by the interaction with the player's
    // RigidBody2D, thus we will put this code in FixedUpdate()

    void FixedUpdate()
    {
        // We need input. We can search for Input in the unity API. 
        // there is an Input class, accessing keyboard data. . .
        // in the Input class there are class functions and static variables. 
        // in this case we will use Input.GetAxis


        // the keys on the keyboard associated with Horizontal and Vertical
        // are set by the input manager. 
        //float moveHorizontal = forceMultiplier * Input.GetAxis("Horizontal");
        //float moveVertical = forceMultiplier * Input.GetAxis("Vertical");


        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //rb2d.AddForce(movement);

        //if (moveHorizontal == 1)
        //{
        //    rb2d.velocity = vel;
        //    Debug.Log("RIGHT");
        //}
        //else if (moveHorizontal == -1)
        //{
        //    rb2d.velocity = negVel;
        //    Debug.Log("left");
        //}
        //else if (moveHorizontal == 0)
        //{
        //    rb2d.velocity = zeroVector;
        //}



        // Aight, in order to get keyboard data, we use the "Input" class and then
        // GetAxis, which gets us the associated data from the given axis, based upon
        // keyboard input. 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // rb2d.velocity gives us the current velocity of the rigidbody, and can be changed 
        // with a given Vector2, which is what we are doing with the moveHorizontal = Input.GetAxis 

        rb2d.velocity = new Vector2(moveHorizontal * forceMultiplier, moveVertical);


        // We use this so as to debug 
        mugabe++;
        if (mugabe > 100)
        {
            Debug.Log(moveHorizontal);
            Debug.Log(rb2d.velocity);

            mugabe = 0;
        }


    }

    void Update()
    {
        if(rb2d.velocity != zeroVector)
        {
            anim.SetBool("playerMove", true);
        }
        else
        {
            anim.SetBool("playerMove", false);
        }
    }
}
