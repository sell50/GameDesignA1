using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

public class MainMenu : MonoBehaviour
{
    public void LoadScores()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene(4);
    }
}
