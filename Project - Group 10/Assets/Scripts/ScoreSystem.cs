using UnityEngine;

namespace ScoreSystem
{
    public class BasicScoreSystem: MonoBehaviour
    {
        public int redPoints;
        public int bluePoints;



        public void RedScore()
        {
            redPoints += 1;
        }

        public int GetTotalRedPoints()
        {
            return redPoints;
        }

        public void BlueScore()
        {
            bluePoints += 1;
        }

        public int GetTotalBluePoints()
        {
            return bluePoints;
        }

    }
}

