using UnityEngine;

namespace Code.Architecture.MeshTest {
    public class MeshTest : MonoBehaviour {
        [SerializeField] private Vector3[] vertices;
        [SerializeField] private int[] triangles;
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private Mesh mesh;
        [Space]
        [SerializeField] private int Width;
        [SerializeField] private int Height;


        public void Start()
        {
            mesh = meshFilter.mesh;

            vertices = new Vector3[(Width + 1) * (Height + 1)];
            for (int i = 0, y = 0; y <= Height; y++)
                for (int x = 0; x <= Width; i++, x++)
                    vertices[i] = new Vector3(x, y);

            triangles = new int[Width * Height * 6];
            for (int iv = 0, vi = 0, y = 0; y < Height; y++, vi++)
                for (int x = 0; x < Width; x++, iv += 6, vi++)
                {
                    triangles[iv] = vi;
                    triangles[iv + 1] = triangles[iv + 4] = vi + Width + 1;
                    triangles[iv + 2] = triangles[iv + 3] = vi + 1;
                    triangles[iv + 5] = vi + Width + 2;
                }
            mesh.vertices = vertices;
            mesh.triangles = triangles;
        }
    }
}