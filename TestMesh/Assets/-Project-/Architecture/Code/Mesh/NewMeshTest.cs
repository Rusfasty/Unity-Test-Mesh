using Code.Architecture.Test.TileCell;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Architecture.MeshTests {
    [RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
    public class NewMeshTest : MonoBehaviour {
        [SerializeField] private Mesh _mesh;
        [SerializeField] private MeshFilter meshFilter;
        [Space]
        [SerializeField] private Vector3[] _uv;
        [SerializeField] private Vector3[] _vertices;
        [SerializeField] private int[] _triangles;

        public const int MAX_SIZE_WIDHT = 64;
        public const int MAX_SIZE_HEIGHT = 64;

        public void Init() {
            _vertices = new Vector3[MAX_SIZE_WIDHT * MAX_SIZE_HEIGHT ];
            _triangles = new int[MAX_SIZE_WIDHT * MAX_SIZE_HEIGHT];
            _mesh = meshFilter.mesh;
        }
        public void Start() {
            Init();
            CreateCell(2, 2);
        }

        public void CreateCell(int x, int y) {
            for (int i = 0; i < 3; i++) {
                _vertices[i] = new Vector3(x, y);
                _vertices[i] = new Vector3(x, y + 1);
                _vertices[i] = new Vector3(x + 1, y + 1);
                _vertices[i] = new Vector3(x + 1, y);
            }
        }
        public void SetTile(int X, int Y) { }
    }
}