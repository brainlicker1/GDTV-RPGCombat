using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] float  moveSpeed = 4;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    
 private void FixedUpdate() {
    rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));
 }


public void MoveTo(Vector2 targetPosition){

    moveDirection = targetPosition;


}
    //end of Class
}
