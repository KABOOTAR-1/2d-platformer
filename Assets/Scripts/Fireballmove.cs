using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballmove : MonoBehaviour
{
    public GameObject t1;
    Transform t;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + (Vector2)transform.right, 3*Time.deltaTime);
    }
}
