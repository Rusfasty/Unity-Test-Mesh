using UnityEngine;

namespace Code.Architecture.MeshTest {
    [System.Serializable]
    public class MeshGridTester<T> {
        [field: SerializeField] public T[,] Grid { get; private set; }

        [field: SerializeField] public readonly int XSize, YSize;

        [field: SerializeField] public int XSizeGrid { get; private set; }
        [field: SerializeField] public int YSizeGrid { get; private set; }

        [field: SerializeField] public MeshFilter Mesh { get; private set; }
        [field: SerializeField] public MeshCollider MeshCollider { get; private set; }


        public MeshGridTester(int xSize,int ySize,T Cell) {
            XSize = xSize;
            YSize = ySize;


        }
        private void SetMesh(Vector2Int Point) {

        }

        public void SetSizeGrid(Vector2Int Size) {
            XSizeGrid = Size.x;
            YSizeGrid = Size.y;
        }
    }
}