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
        //   public Text coinText;

        
        void Start()
        {
            Tags.facingRight = true;

        }

        void Update()
        {
           

            for (int i = 0; i < player.Length; i++)
            {
                if (player[i].deathState == true)
                {
                    playerGameObject.SetActive(false);
                    GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
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
