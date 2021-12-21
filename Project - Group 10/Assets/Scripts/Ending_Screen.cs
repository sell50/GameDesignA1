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
        score.text = "Score: " + points.GetTotalPoints().ToString();
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
