using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreSystem
{
    public class Flag : BasicScoreSystem
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Base")
            {
                Score();
            }
        }

    }
}