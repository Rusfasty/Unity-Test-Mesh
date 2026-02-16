using UnityEngine;

namespace Code.Architecture.Test {
    public class Tester : MonoBehaviour {
        [SerializeField] private Grid.Grid2D Grid;
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private int X, Y;
        public void Awake() {
            Grid = new(1);
            Grid.CreateGrid(X, Y);

            meshFilter.mesh = Grid.GetMesh();
            //for (int y = 0, xi = 0, vi = 0; y < Hidht; y++,vi += 4)
            //    for (int x = 0; x < Width; x++, xi += 4) {
            //        _vertictes[xi + vi] = new Vector3(x / _SizeCell.x, y / _SizeCell.y);
            //        _vertictes[xi + 1 + vi] = new Vector3(x / _SizeCell.x, y / _SizeCell.y + 1);
            //        _vertictes[xi + 2 + vi] = new Vector3(x / _SizeCell.x + 1, y / _SizeCell.y + 1);
            //        _vertictes[xi + 3 + vi] = new Vector3(x / _SizeCell.x + 1, y / _SizeCell.y);
            //    }
            //_triangles[vi] = 0;
            //_triangles[vi + 1] = 2;
            //_triangles[vi + 2] = 3;

            //_triangles[vi + 3] = 0;
            //_triangles[vi + 4] = 3;
            //_triangles[vi + 5] = 1;

            //_triangles[vi] = _triangles[vi + 3] = iv;
            //_triangles[vi + 1] = iv + 2;
            //_triangles[vi + 2] = _triangles[vi + 4] = iv + 3;
            //_triangles[vi + 5] = iv + 1;
        }


    }
}