using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreSystem
{
    public class BlueFlag : BasicScoreSystem
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "RedBase")
            {
                BlueScore();
            }
        }

    }
}