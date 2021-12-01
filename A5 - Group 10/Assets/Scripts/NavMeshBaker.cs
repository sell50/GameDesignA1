using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    [SerializeField] NavMeshSurface[] navMeshSurfaces;

    private void Awake()
    {
        BakeNavMesh();
    }

    public void BakeNavMesh()
    {
        foreach (var navMeshSurface in navMeshSurfaces)
        {
            navMeshSurface.BuildNavMesh();
        }
    }
}
