using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

     public void ReduceHealth(int damageDealt)
        {
            health -= damageDealt;
        }

        public void IncreaseHealth(int hpHealed)
        {
            health += hpHealed;
        }
}
