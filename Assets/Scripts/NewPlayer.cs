using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    public GameObject playerclone;
    public GameObject player;
    void Start()
    {
        playerclone.transform.position = transform.position;
        Invoke("Des", 5);
    }


    private void Update()
    {
        playerclone.transform.localScale = player.transform.localScale;
    }
    void Des()
    {
        if(playerclone!=null)
            playerclone.SetActive(false);
            Invoke("Des", 5);
            
        
    }
}

    // Update is called once per frame
    

  

