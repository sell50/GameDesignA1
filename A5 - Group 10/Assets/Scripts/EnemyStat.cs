using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{

    public float MaxHP = 100;
    public float HP;
    
    public void takeDMG()
    {

        if (HP <= 0) Destroy(gameObject);
        else HP -= 0.1f;
    }
}
