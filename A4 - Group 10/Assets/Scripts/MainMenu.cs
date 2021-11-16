using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        Loader.Load(Loader.Scene.ChantalLevel);
    }
}
