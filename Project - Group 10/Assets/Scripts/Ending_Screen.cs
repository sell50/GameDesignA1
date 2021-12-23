using UnityEngine;
using UnityEngine.UI;
using ScoreSystem;
using UnityEngine.SceneManagement;
using TMPro;
public class Ending_Screen : MonoBehaviour 
{
    public TMP_Text score;
    public BasicScoreSystem points = new BasicScoreSystem();

    public void DisplayScore()                                              //Call after game ends to display score
    {
        score.text = "Red Score: " + points.GetTotalRedPoints().ToString();
        score.text = "Blue Score: " + points.GetTotalBluePoints().ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
