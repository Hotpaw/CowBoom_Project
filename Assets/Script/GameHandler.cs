using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(("Game Scene"));
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Debug.Log("Test");
        SceneManager.LoadScene("Main Menu");
    }
}
