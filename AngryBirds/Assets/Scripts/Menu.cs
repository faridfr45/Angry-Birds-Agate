using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayLevel1(){
        SceneManager.LoadScene("Level 1");
    }

    public void PlayLevel2(){
        SceneManager.LoadScene("Level 2");
    }

    public void Exit(){
        Application.Quit();
    }
}
