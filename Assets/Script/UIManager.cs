using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject winGame;
    public GameObject loseGame;
    // Start is called before the first frame update
    void Start()
    {
        winGame.SetActive(false);
        loseGame.SetActive(false);  

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinGame()
    {
        winGame.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoseGame()
    {
        Time.timeScale = 0;
        loseGame.SetActive(true);
    }
}
