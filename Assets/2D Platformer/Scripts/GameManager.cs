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

        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
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
                GameObject.Find("Wall").GetComponent<Wall>().enabled = false;
            }
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.sceneCount);
        }

        public void ReloadCheckpoint()
        {
            if (!player.lastCheckpoint)
            {
                playerGameObject.transform.position = player.lastCheckpoint.transform.position;
            }
            else
            {
                ReloadLevel();
            }
        }
    }
}
