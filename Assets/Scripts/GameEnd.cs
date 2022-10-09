using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag=="Player"){
                Time.timeScale=0f;
                
 Invoke("RE",3f);
            }
            
        }

        private void RE(){
              Application.LoadLevel(Application.loadedLevel);
        }
}
