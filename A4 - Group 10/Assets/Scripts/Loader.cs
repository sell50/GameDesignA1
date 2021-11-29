using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    public static void Load(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
