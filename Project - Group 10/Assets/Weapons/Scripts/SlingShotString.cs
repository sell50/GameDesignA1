using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotString : MonoBehaviour
{
    public Transform left;
    public Transform centre;
    public Transform right;

    LineRenderer slingString;

    void Start()
    {
        slingString = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        slingString.SetPositions(new Vector3[3] { left.position, centre.position, right.position });
    }
}
