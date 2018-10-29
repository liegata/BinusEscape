using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {


    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    //[SerializeField]Text text; pake INI
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController2D>();
	}
	
	// Update is called once per frame
	void Update () {
       //text.text = "HP :" + horizontalMove; ini untuk HP di game manager display
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //pakai mathf.abs buat speed nya selalu positive atau jalan dengan benar
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

       
	}

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }

    private void FixedUpdate()
    {
        //move the character
        controller.Move(horizontalMove*Time.fixedDeltaTime, crouch, jump);
        jump = false;
        crouch = false;
        
    }
    public void Jump()
    {
            jump = true;
            animator.SetBool("IsJumping", true);        

    }
    public void Crouch()
    {
       
            crouch = true;

    }     

}
