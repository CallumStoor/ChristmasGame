using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int coinsCounter = 0;

        public GameObject playerGameObject;
        public GameObject deathScreen;
        private PlayerController player;
        public GameObject deathPlayerPrefab;
        public Text coinText;
        private GameObject wall;

        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            wall = GameObject.Find("Wall");
        }

        void Update()
        {
            coinText.text = coinsCounter.ToString();
            if(player.deathState == true)
            {
                deathScreen.SetActive(true);
                playerGameObject.SetActive(false);
                GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
                player.deathState = false;
                wall.GetComponent<Wall>().enabled = false;
            }
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.sceneCount);
        }

        public void ReloadCheckpoint()
        {
            if (player.lastCheckpoint != null)
            {
                wall.transform.position = player.lastCheckpoint.transform.position - new Vector3( 10, 0, 0);
                playerGameObject.transform.position = player.lastCheckpoint.transform.position;
                player.deathState = false;
                wall.GetComponent<Wall>().enabled = true;
                playerGameObject.SetActive(true);
                deathScreen.SetActive(false);
            }
            else
            {
                ReloadLevel();
            }
        }


    }
}
