using Code.Architecture.Grid;
using UnityEngine;

public class TesterGridUV2D : MonoBehaviour {
    [SerializeField] private GridUV2D gridUV2D;
    [SerializeField] private MeshFilter meshFilter;

    private void Start() {
        gridUV2D.Start();
        meshFilter.mesh = gridUV2D.GetMesh;
    }
}