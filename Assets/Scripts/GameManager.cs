using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject xpBarPanel;
    [SerializeField] private GameObject levelUpPanel;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        xpBarPanel.SetActive(true);
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(!_player.GetComponent<Player>().isAlive){
            gameOverPanel.SetActive(true);
            xpBarPanel.SetActive(false);
            levelUpPanel.SetActive(false);
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
    }
}
