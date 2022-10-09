using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int coinsCounter = 0;

        public GameObject playerGameObject;
        public PlayerController[] player;
        public GameObject deathPlayerPrefab;
        public Transform clonepos;
        public Collider2D coll;
        //   public Text coinText;

        
        void Start()
        {
            Tags.facingRight = true;
            Tags.score = 0;

        }

        void Update()
        {
            coll = Physics2D.OverlapCircle(clonepos.position, 0.25f);
            if (Input.GetKeyDown(KeyCode.C) && coll==null )
            {
                player[player.Length - 1].gameObject.transform.position = clonepos.position;
                player[player.Length - 1].gameObject.SetActive(true);
     
            }
            for (int i = 0; i < player.Length; i++)
            {
                if (player[i].deathState == true)
                {
                    playerGameObject.SetActive(false);
                    GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                    if(player.Length>1)
                    Destroy(player[player.Length-1].gameObject);
                    deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
                    player[i].deathState = false;
                    Invoke("ReloadLevel", 3);
                }
            }

           
        }

        private void ReloadLevel()
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
