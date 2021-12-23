using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreSystem
{
    public class RedFlag : BasicScoreSystem
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "BlueBase")
            {
                RedScore();
                other.transform.parent = null;
                other.transform.position = GameObject.FindWithTag("RedBase").transform.position;
            }
        }

    }
}