using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    [SerializeField] NavMeshSurface[] navMeshSurfaces;

    private void Start()
    {
        BakeNavMesh();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BakeNavMesh();
        }
    }

    public void BakeNavMesh()
    {
        foreach (var navMeshSurface in navMeshSurfaces)
        {
            navMeshSurface.BuildNavMesh();
        }
    }
    
    //todo: find way to rebuild navmesh after level has been generated - add reference to NavMeshBaker in PLG script?
}
