using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject fireball;
    float newtime = 0f;
    float timegap =0.0015f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = transform.parent;
       
        if (Input.GetKeyDown(KeyCode.F) && Time.time>newtime)
        {
            newtime = Time.time + timegap/Time.deltaTime;
            Instantiate(fireball, transform.position, Quaternion.identity);
        }
    }
}
