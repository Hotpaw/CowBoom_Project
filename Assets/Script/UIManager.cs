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
        winGame.SetActive(true);
        loseGame.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
    }

    void WinGame()
    {
        winGame.SetActive(true);
    }

    void LoseGame()
    {
        loseGame.SetActive(false);
    }
}
