using Code.Architecture.Grid;
using UnityEngine;

namespace Code.Architecture.Test {
    public class TesterGridTile2D : MonoBehaviour {
        [SerializeField] private GridTile2D _grid;
        [SerializeField] private MeshFilter _mesh;

        [SerializeField] private Camera _camera;
        private void Start() {
            _grid = new(new Vector2(0,0));
            _grid.UpdateDataEvent += UpdateDataGrid;
            _grid.CreateGrid(3,3);
        }
        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                _grid.GetXY(_camera.ScreenToWorldPoint(Input.mousePosition),out var x,out var y);
                Debug.Log($"X:{x}, Y:{y}");
                _grid.CreateCell(new Vector2Int(x,y),new Vector2Int(3,7));
            }
        }
        private void UpdateDataGrid() {
            _mesh.mesh = _grid.GetMesh;
        }
    }
}