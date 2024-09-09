using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidScript : MonoBehaviour
{   

    public float speed;
    public GameObject spaceDiamond;
    public Transform player;
    private PolygonCollider2D coll;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(0,1),Random.Range(0,1)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("collision!");
        
        if(other.tag == "Player"){
            Instantiate(spaceDiamond, onTriggerHelper(gameObject.transform.position), Quaternion.identity);
            Instantiate(spaceDiamond, onTriggerHelper(gameObject.transform.position), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private Vector3 onTriggerHelper(Vector3 pos){
    
    Vector3 newPos = new Vector3(pos.x + Random.Range(-.25f,0.25f), pos.y + Random.Range(-.25f,0.25f), pos.z);
    
        return newPos;
    }
}
