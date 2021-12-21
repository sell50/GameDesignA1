using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public static AudioClip buttonSound;
    static AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        // SceneManager.LoadScene()         //Loading level
        PlaySound();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlaySound()
    {
        buttonSound = audioSrc.GetComponent<AudioClip>();
        audioSrc.PlayOneShot(buttonSound);
    }
}
