using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
//using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private List<KeyCode> keysPressed = new List<KeyCode>();
    public float movementSpeed = .2f;
    public float boostSpeed = .4f;
    public float turnSpeed = 1;
    public float maxTurnSpeed = 20;
    public float brakeCutoff = .001f;
    public float angularBrakeCutoff = .0001f;
    private float bulletSpeed = 1.25f;
    public GameObject projectile;
    
    private bool turningLeft = false;
    private bool turningRight = false;
    private bool movingForward = false;
    private bool braking = false;
    private bool boosting = false;
    private bool firing;
    



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {   

        // BoundsCheck();
        
        keyCheck(KeyCode.D, ref turningRight);
        keyCheck(KeyCode.A, ref turningLeft);
        keyCheck(KeyCode.W, ref movingForward);
        keyCheck(KeyCode.S, ref braking);
        keyCheck(KeyCode.LeftShift, ref boosting);
        keyCheck(KeyCode.Space, ref firing);

        // if(Input.GetKeyDown(KeyCode.Space)){
        //     shoot();
        // }

        if(turningLeft) {
            onTurnLeft();
        }
        if(turningRight) {
            onTurnRight();
        }
        if(movingForward) {
            moveFoward();
        }
        if(braking) {
            linearBrake();
        }


    }

    private void keyCheck(KeyCode key,ref bool pressed){
        if (Input.GetKeyDown(key))
            pressed = true;
        if (Input.GetKeyUp(key))
            pressed = false;
    }

    private void onTurnLeft() {
        rb.AddTorque(turnSpeed);
    }
    private void onTurnRight() {
        rb.AddTorque(-turnSpeed);
    }

    private void linearBrake(){
        if(rb.velocity.x < brakeCutoff && rb.velocity.y < brakeCutoff){
            rb.velocity = new Vector2(0,0);
        }else{
            rb.AddForce(-rb.velocity/10);
        }

    }

    // private void angularBrake(){
    //     if(rb.angularVelocity < brakeCutoff){
    //         rb.angularVelocity = 0f;
    //     }else{
    //         rb.AddTorque(-rb.angularVelocity/1.3f);
    //     }
    // }

    private void moveFoward(){
        //Debug.Log(rb.velocity.magnitude);
        if (boosting) {
            rb.AddForce(transform.up * boostSpeed);
        } else if (rb.velocity.magnitude < 10) {
            rb.AddForce(transform.up * movementSpeed);
        }
    }

    private void shoot(){

        GameObject newProj = Instantiate(projectile, transform.position, Quaternion.identity);
        Rigidbody2D projRb = newProj.GetComponent<Rigidbody2D>();
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "target" && !boosting){
            gameObject.transform.position = new Vector3(0,0,0);
            rb.velocity = new Vector2(0,0);
        }
    }
}
