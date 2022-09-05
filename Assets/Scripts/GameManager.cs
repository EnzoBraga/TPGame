using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(!_player.GetComponent<Player>().isAlive){
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
