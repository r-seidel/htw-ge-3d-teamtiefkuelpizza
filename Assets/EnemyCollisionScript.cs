using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionScript : MonoBehaviour
{
    public SkinnedMeshRenderer meshRenderer;
    public MeshCollider coll;

    private void Start()
    {
        UpdateCollider();
    }

    public void UpdateCollider()
    {
        Mesh colliderMesh = new Mesh();
        meshRenderer.BakeMesh(colliderMesh);
        coll.sharedMesh = null;
        coll.sharedMesh = colliderMesh;
    }
}
