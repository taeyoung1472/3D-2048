using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D holeCollider;
    [SerializeField]
    private PolygonCollider2D groundCollider;

    [SerializeField]
    private MeshCollider generatedMeshCollider;

    private Mesh generatedMesh;

    private void FixedUpdate() {
        if(transform.hasChanged == true){
            transform.hasChanged = false;
            holeCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
            MakeHole();
            Make3DMeshCollider();
        }
    }
    private void MakeHole(){
        Vector2[] pointPositions = holeCollider.GetPath(0);

        for (int i = 0; i < pointPositions.Length; i++){
            pointPositions[i] = holeCollider.transform.TransformPoint(pointPositions[i]);
        }

        groundCollider.pathCount = 2;
        groundCollider.SetPath(1, pointPositions);
    }
    private void Make3DMeshCollider(){
        if(generatedMesh != null){
            Destroy(generatedMesh);
        }
        generatedMesh = groundCollider.CreateMesh(true, true);
        generatedMeshCollider.sharedMesh = generatedMesh;
    }
}
