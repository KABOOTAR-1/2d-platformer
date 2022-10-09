using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
     [SerializeField]
    public GameObject en ;
    // Start is called before the first frame update
    void Start()
    {
        
        en.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag=="Player"){
                
                Invoke("RE",3f);
                en.SetActive(true);
            }
            
        }

        private void RE(){
              Application.LoadLevel(Application.loadedLevel);
        }
}
