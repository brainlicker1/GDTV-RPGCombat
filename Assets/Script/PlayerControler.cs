using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControler : MonoBehaviour
{
  [SerializeField] private float moveSpeed = 1f ;

  private PlayerControls playerControls;
  private Vector2 movement;
  private Rigidbody2D rb;
  private Animator myAnimator;
  private SpriteRenderer mySpriteRenderer;

  private void Awake() {
    playerControls = new PlayerControls();
    rb = GetComponent<Rigidbody2D>();
    myAnimator = GetComponent<Animator>();
    mySpriteRenderer = GetComponent<SpriteRenderer>();
  }
    private void OnEnable() {
    playerControls.Enable();
   }
     private void FixedUpdate() {
         PlayerInput();
         AdjustPlayerFaceingDirection();
  }
     private void Update() {
      Move();
    }
    private void PlayerInput(){
    movement = playerControls.Movement.Move.ReadValue<Vector2>();
    myAnimator.SetFloat("moveX",movement.x);
    myAnimator.SetFloat("moveY", movement.y);
    
  }

  private void Move(){
    rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    
  }

  private void AdjustPlayerFaceingDirection(){

      Vector3 mousePos = Input.mousePosition;
      Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
    if(mousePos.x < playerScreenPoint.x){
      mySpriteRenderer.flipX = true;

    } else{

      mySpriteRenderer.flipX = false;
    }

  }

   //end Of Class
}
