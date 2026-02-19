using UnityEngine;

namespace Code.Architecture.Test {
    public class Tester : MonoBehaviour {
        [SerializeField] private Grid.Grid2D Grid;
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private Camera Camera;
        [SerializeField] private int X, Y;
        [SerializeField] private float Width, Hidht;
        [SerializeField] private Vector3 _WorldPoint;

        public void Awake() {
            Grid = new(_WorldPoint);
        }
        public void Creale() {
            Grid.SetSizeGrid(Width, Hidht);
            Grid.CreateGrid(X, Y);

            meshFilter.mesh = Grid.GetMesh();
        }
        public void Update() {
            if (Input.GetKey(KeyCode.F)) {
                Grid.SetSizeGrid(Width, Hidht);
                Grid.CreateGrid(X, Y);

                meshFilter.mesh = Grid.GetMesh();
            }
            if (Input.GetMouseButtonDown(0)) {
                Grid.GetXY(Camera.ScreenToWorldPoint(Input.mousePosition), out var x, out int y);
                Debug.Log($"X:{x}, Y:{y}");
                Grid.SetTile(new Vector3(x, y), 66);
            }
        }
    }
}