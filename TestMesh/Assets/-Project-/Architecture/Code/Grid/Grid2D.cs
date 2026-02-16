using UnityEngine;

namespace Code.Architecture.Grid {
    [System.Serializable]
    public class Grid2D {
        [SerializeField] private Vector3 _SizeCell;

        [SerializeField] public Mesh _mesh;
        [SerializeField] private Vector3[] _vertictes;
        [SerializeField] private int[] _triangles;

        public Grid2D(int SizeCell) {
            _SizeCell = new Vector3(0.75f, 1, 0);
        }

        public void CreateGrid(int Width, int Hidht) {
            _mesh = new();

            _vertictes = new Vector3[(Width + 1) * ( 1 + Hidht)];
            for (int y = 0, i = 0; y <= Hidht; y++)
                for (int x = 0; x <= Width; x++, i++)
                    _vertictes[i] = new Vector3(x * _SizeCell.x, y * _SizeCell.y);

            _triangles = new int[Width * Hidht * 6];
            for (int y = 0,vi = 0,iv = 0; y < Hidht; y++, iv++)
                for (int x = 0; x < Width; x++, vi += 6, iv++) {
                    _triangles[vi] = iv + Width + 1;
                    _triangles[vi + 1] = _triangles[vi + 4] = iv + Width + 2; 
                    _triangles[vi + 2] = iv = _triangles[vi + 3] = iv; ;
                    _triangles[vi + 5] = iv + 1;
                }
            _mesh.vertices = _vertictes;
            _mesh.triangles = _triangles;
        }
        public void SetTile(Vector3Int XY) { }
        public Mesh GetMesh() => _mesh;
        //public Vector3 GetXY(Vectory3int XY, out Tile Tile) { }
    }
}