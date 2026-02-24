using System;
using System.Drawing;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Code.Architecture.Grid {
    [System.Serializable]
    public class GridTile2D {
        [SerializeField] private Vector3[] _vertictes;
        [SerializeField] private Vector2[] _uv;
        [SerializeField] private int[] _triangles;
        [Space]
        [SerializeField] private Vector3 _SizeCell;
        [SerializeField] private Vector3 _WorldPoint;
        [SerializeField] private int[,] _cell;

        [SerializeField] private Mesh _mesh;

        public GridTile2D(Vector2 WorldPoint) {
            _WorldPoint = WorldPoint;
            _SizeCell = new Vector3(1, 1);
        }

        public void CreateGrid(int Widht, int Hidht) {
            _mesh = new();
            _vertictes = new Vector3[(Widht + 1) * (1 + Hidht)];
            _uv = new Vector2[_vertictes.Length];
            //for (int y = 0, Index = 0; y <= Hidht; y++)
            //    for (int x = 0; x <= Widht; x++, Index++) {
            //        _vertictes[Index] = new Vector3(x / _SizeCell.x, y / _SizeCell.y);
            //    }
            _triangles = new int[Widht * Hidht * 6];

            for (int y = 0; y < Hidht; y++)
                for (int x = 0; x < Widht; x++)
                    CreateCell(new Vector2Int(x,y),new Vector2Int((int)_SizeCell.x, (int)_SizeCell.y));
            _mesh.vertices = _vertictes;
            _mesh.uv = _uv;
            _mesh.triangles = _triangles;
        }
        public void UpdateDate() {
            _mesh = new();
            _mesh.vertices = _vertictes;
            _mesh.uv = _uv;
            _mesh.triangles = _triangles;

            UpdateDataEvent?.Invoke();
        }
        public void CreateCell(Vector2Int XY,Vector2Int Size) {
            //_vertictes = new Vector3[(Size.x + 1) * (1 + Size.y)];
            for (int y = 0, Index = 0; y <= Size.y; y++)
                for (int x = 0; x <= Size.x; x++, Index ++) {
                    _vertictes[Index] = new Vector3(x / _SizeCell.x + XY.x, y / _SizeCell.y + XY.y);
                    _uv[Index] = new Vector2((float)x / Size.x, (float)y / Size.y);
                }

            //_triangles = new int[Size.x * Size.y * 6];
            for (int y = 0, vi = 0, iv = 0; y < Size.x; y++, iv++)
                for (int x = 0; x < Size.y; x++, vi += 6, iv++) {
                    _triangles[vi] = iv + Size.x + 1;
                    _triangles[vi + 1] = _triangles[vi + 4] = iv + Size.x + 2;
                    _triangles[vi + 2] = iv = _triangles[vi + 3] = iv; ;
                    _triangles[vi + 5] = iv + 1;
                }
            UpdateDate();
        }
        public void SetSizeCell(Vector2 Size) {
            _SizeCell = Size;
        }
        public void GetXY(Vector3 PointXY, out int x, out int y) {
            x = Mathf.FloorToInt((PointXY + _WorldPoint).x / _SizeCell.x);
            y = Mathf.FloorToInt((PointXY + _WorldPoint).y / _SizeCell.y);
        }
        public Vector2 GetWorldPoint => new Vector2(_WorldPoint.x, _WorldPoint.y);
        public Vector2 GetSizeCell => new Vector2(_SizeCell.x, _SizeCell.y);
        public Mesh GetMesh => _mesh;

        public event Action UpdateDataEvent;
    }
}