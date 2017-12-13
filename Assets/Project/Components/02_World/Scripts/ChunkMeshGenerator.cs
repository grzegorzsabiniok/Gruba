using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkMeshGenerator : MonoBehaviour
{
    public Vector2 ok;
    public ComputeShader shader;
    public RenderTexture tex;
    private void Start()
    {
        /*
        int kernelHandle = shader.FindKernel("FillWithRed");
        
        tex = new RenderTexture(256, 256, 24);
        tex.enableRandomWrite = true;
        tex.Create();
        int[] color = new int[1] { 5 };
        shader.SetInts("color", color);
        shader.SetTexture(kernelHandle, "res", tex);
        shader.Dispatch(kernelHandle, 256, 256 / 8, 1);
        print(color[0]);
        */
    }
    private void Update()
    {
        Plane(Vector2.zero);
        Plane(new Vector2(90, 0));
        Plane(new Vector2(90, 90));
        Plane(new Vector2(90, 180));
        Plane(new Vector2(90, 270));
    }
    /*
    public Mesh[] GenerateMeshes(Block[,,] source,bool top=false)
    {
        Mesh mesh = new Mesh();

        return mesh;
    }
    private Mesh GenerateLevel(Block[,,] source,int level,bool top=false)
    {

    }
    */
    private void Plane(Vector2 rotation)
    {
        rotation *= Mathf.PI / 180;
        Mesh mesh = new Mesh();
        List<Vector3> v = new List<Vector3>();
        v.Add(Rotate(new Vector3(1, 1, 1), rotation));
        v.Add(Rotate(new Vector3(1, 1, -1), rotation));
        v.Add(Rotate(new Vector3(-1, 1, 1), rotation));
        v.Add(Rotate(new Vector3(-1, 1, -1), rotation));

        mesh.SetVertices(v);
        mesh.SetTriangles(new int[] { 3, 2, 0, 3, 0, 1 }, 0);
        GetComponent<MeshFilter>().mesh = mesh;
    }
    private Vector3 Rotate(Vector3 position, Vector2 rotation)
    {
        position = new Vector3(position.x,
            position.y * Mathf.Cos(rotation.x) - position.z * Mathf.Sin(rotation.x),
           position.y * Mathf.Sin(rotation.x) + position.z * Mathf.Cos(rotation.x));
        position = new Vector3(position.z * Mathf.Sin(rotation.y) + position.x * Mathf.Cos(rotation.y),
           position.y,
           position.z * Mathf.Cos(rotation.y) - position.x * Mathf.Sin(rotation.y));
        return position;
    }
}
