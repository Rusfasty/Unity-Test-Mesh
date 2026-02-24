using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Code.Architecture.Grid {
    [System.Serializable]
    public class GridUV2D {
        [SerializeField] private Vector3[] _vertictes;
        [SerializeField] private Vector2[] _uv;
        [SerializeField] private int[] _triangles;
        [Space]
        [SerializeField] private Vector3 _SizeCell;
        [SerializeField] private Vector3 _WorldPoint;
        [SerializeField] private Mesh _mesh;

        public void Start() {
            CreateCell(0, 0);
        }
        private void CreateCell(int X, int Y) {
            _mesh = new();
            _vertictes = new Vector3[4];
            _vertictes[0] = new Vector3(0, 1);
            _vertictes[1] = new Vector3(1, 1);
            _vertictes[2] = new Vector3(0, 0);
            _vertictes[3] = new Vector3(1, 0);

            _triangles = new int[6];
            _triangles[0] = 0;
            _triangles[1] = _triangles[4] = 1;
            _triangles[2] = _triangles[3] = 2;
            _triangles[5] = 3;

            _uv = new Vector2[4];
            _uv[0] = new Vector3(0,1);
            _uv[1] = new Vector3(1,1);
            _uv[2] = new Vector3(0,0);
            _uv[3] = new Vector3(1,0);

            _mesh.vertices = _vertictes;
            _mesh.uv = _uv;
            _mesh.triangles = _triangles;
        }
        public Mesh GetMesh => _mesh;

    }
}