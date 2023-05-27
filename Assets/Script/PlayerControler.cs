using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControler : MonoBehaviour
{
  [SerializeField] private float moveSpeed = 1f ;  //allows adjustment of player movement speed

  private PlayerControls playerControls; // assigns player controls to a useable variable
  private Vector2 movement;   // makes a vector 2 variable named movement
  private Rigidbody2D rb;  // makes a rigid body variable
  private Animator myAnimator; // makes an animator with a useable name
  private SpriteRenderer mySpriteRenderer; // makes sprite renderer into a useable thang

  private void Awake() {
    playerControls = new PlayerControls();
    rb = GetComponent<Rigidbody2D>(); //rb is turned into the shortcut to the rigid body on the player
    myAnimator = GetComponent<Animator>();
    mySpriteRenderer = GetComponent<SpriteRenderer>();   // gets the stuff for the thing to let it be the thing
  }

  //enables controls just after programe wakes
    private void OnEnable() {
    playerControls.Enable();
   }

   //idk what the fixed update does, but it does stuff
     private void FixedUpdate() {
         PlayerInput();  //checks for player input then says HEY MOVE FUNCTION, DO STUFF
         AdjustPlayerFaceingDirection(); //changes player direction to face the mouse cursor
  }
  //update is called each frame, the move funtion moves the player according to player input
     private void Update() {
      Move();
    }
    private void PlayerInput(){    //some sort of C# wizardry
    movement = playerControls.Movement.Move.ReadValue<Vector2>();
    myAnimator.SetFloat("moveX",movement.x);
    myAnimator.SetFloat("moveY", movement.y);
    
  }

  private void Move(){  // gets the rigid body of the player to move by adding the v2 input to the rb position after * it by moveSpeed which is * by delta time, dude said opimized way of doing it, idk
    rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    
  }

  private void AdjustPlayerFaceingDirection(){

      Vector3 mousePos = Input.mousePosition;  // assigns the position of the mouse to mouse pos, not sure wy a v2 wouldnt work, but oh well
      Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);  // assings the position of the main camera to playerScreenPoint
    if(mousePos.x < playerScreenPoint.x){  // checks to see if mouse position on x axis is left or right of the camera position
      mySpriteRenderer.flipX = true;  // if the position is less than the camera position on the x axis it makes the player face left

    } else{

      mySpriteRenderer.flipX = false; // if the position is to the right of the cam, leaves player facing right
    }

  }

   //end Of Class
}
