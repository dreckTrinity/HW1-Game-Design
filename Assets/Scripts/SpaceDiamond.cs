using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceDiamondScript : MonoBehaviour
{
    // Start is called before the first frame update

    private PolygonCollider2D coll;
    private Rigidbody2D rb;
    void Start()
    {
        coll = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(0f,10f),Random.Range(0f,10f))); 
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            //Destroy(gameObject);
            Debug.Log("Ya Struck Diamond!");
        }
    }
}
