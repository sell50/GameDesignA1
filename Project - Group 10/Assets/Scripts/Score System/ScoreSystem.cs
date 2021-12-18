using UnityEngine;

namespace ScoreSystem
{
    public class BasicScoreSystem
    {
        public int TeamPoints;
        
        public void Score()
        {
            TeamPoints+=1; 
        }

        public int GetTotalPoints()
        {
            return TeamPoints;
        }

    }
}

