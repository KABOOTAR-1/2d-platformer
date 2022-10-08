using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    public GameObject playerclone;
    GameObject clone;
    void Start()
    {
        playerclone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && playerclone.activeSelf == false)
        {
            playerclone.SetActive(true);
            playerclone.transform.position=transform.position;
        }
        /*if (playerclone.activeSelf == true)
            Invoke("Des", 5);*/
    }

    private void Des()
    {
        playerclone.SetActive(false);
    }
}
