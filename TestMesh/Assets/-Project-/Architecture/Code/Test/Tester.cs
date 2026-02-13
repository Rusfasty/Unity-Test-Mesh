using Code.Architecture.MeshTest;
using UnityEngine;

namespace Code.Architecture.Test {
    public class Tester : MonoBehaviour {
        [SerializeField] private MeshGridTester<TileCell.Tile> Grid;
        [SerializeField] private TileCell.Tile _tile;

        private void Start() {
            Grid = new(1,1, _tile);
        }
    }
}
