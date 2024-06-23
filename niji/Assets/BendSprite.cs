using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class BendSprite : MonoBehaviour
{
    public float bendFactor = 1.0f; // 曲げる強さを調整

    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;

        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 v = vertices[i];
            v.y += Mathf.Sin(v.x * bendFactor) * bendFactor;
            vertices[i] = v;
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }
}
