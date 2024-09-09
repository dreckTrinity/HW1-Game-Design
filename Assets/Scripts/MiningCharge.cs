using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningCharge : MonoBehaviour 
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    public CapsuleCollider2D coll;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        rb.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("collision!");
        
        if(other.tag == "Target"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

