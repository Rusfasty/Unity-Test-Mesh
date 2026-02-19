using UnityEngine;

namespace Code.Architecture.Grid {
    [System.Serializable]
    public class Grid2D {
        [SerializeField] private Vector3 _SizeCell;
        [SerializeField] private Vector3 _WorldPoint;

        [SerializeField] public Mesh _mesh;
        [SerializeField] private Vector3[] _vertictes;
        [SerializeField] private Vector2[] _UV;
        [SerializeField] private int[] _triangles;

        [SerializeField] private int[,] Cell;

        public Grid2D(Vector2 WorldPoint) {
            _SizeCell = new Vector3(1, 1, 0);
            _WorldPoint = WorldPoint;
        }

        public void CreateGrid(int Width, int Hidht) {
            _mesh = new();
            Cell = new int[Width,Hidht];

            _vertictes = new Vector3[(Width + 1) * ( 1 + Hidht)];
            _UV = new Vector2[_vertictes.Length];
            for (int y = 0, i = 0; y <= Hidht; y++)
                for (int x = 0; x <= Width; x++, i++) {
                    _vertictes[i] = new Vector3(x * _SizeCell.x, y * _SizeCell.y);
                    _UV[i] = new Vector2((float)x / Width, (float)y / Hidht);
                }
            _triangles = new int[Width * Hidht * 6];
            for (int y = 0,vi = 0,iv = 0; y < Hidht; y++, iv++)
                for (int x = 0; x < Width; x++, vi += 6, iv++) {
                    _triangles[vi] = iv + Width + 1;
                    _triangles[vi + 1] = _triangles[vi + 4] = iv + Width + 2; 
                    _triangles[vi + 2] = iv = _triangles[vi + 3] = iv; ;
                    _triangles[vi + 5] = iv + 1;

                    //_UV[vi].Set(iv, iv + Width);
                    //_UV[vi + 1].Set(iv + 1, iv + Width);
                    //_UV[vi + 2].Set(iv, iv);
                    //_UV[vi + 3].Set(iv + 1, iv);
                }
            _mesh.vertices = _vertictes;
            _mesh.uv = _UV;
            _mesh.triangles = _triangles;
        }
        public void SetTexture() {

        }
        private Vector2 ConvertioPixelsToUVCoordination(int x,int y,int TextureWidth, int TextureHidht) {
            return new Vector2((float)x / TextureWidth, (float)y / TextureHidht);
        }
        public void SetSizeGrid(float SizeCellWidth, float SizeCellHidht) =>
            _SizeCell = new Vector3(SizeCellWidth, SizeCellHidht, 0);

        public void SetTile(Vector3 XY,int value) {
            Cell[(int)XY.x,(int)XY.y] = value;
        }
        public int GetTIle(Vector3 XY) {
            return Cell[(int)XY.x, (int)XY.y];
        }

        public void GetXY(Vector3 XY, out int x,out int y) {
            x = Mathf.FloorToInt((XY + _WorldPoint).x / _SizeCell.x);
            y = Mathf.FloorToInt((XY +_WorldPoint).y / _SizeCell.y);
        }
        public Mesh GetMesh() => _mesh;
    }
}