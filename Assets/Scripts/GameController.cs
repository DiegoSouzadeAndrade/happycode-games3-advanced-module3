using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    public GameObject notePanel, gameOverPanel;
    public int collected;
    public int collectedTarget;
    void Start()
    {
        collected = 0;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void AddCollected() {
        collected++;
    }

    public void IsGameOver() {
        if (collected == collectedTarget && !notePanel.gameObject.activeInHierarchy) {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
