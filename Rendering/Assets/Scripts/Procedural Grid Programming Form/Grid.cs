using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
    public int _xSize, _ySize;
    private Mesh _mesh;

    void Awake()
    {
        Generate();
    }

    private Vector3[] _vertices;
    private Vector2[] _uvs;
    private Vector4[] _tangets;

    private void Generate()
    {
        _vertices = new Vector3[(_xSize + 1) * (_ySize + 1)];
        _uvs = new Vector2[_vertices.Length];
        _tangets = new Vector4[_vertices.Length];
        Vector4 tanget = new Vector4(1f, 0f, 0f, -1f);
        GetComponent<MeshFilter>().mesh = _mesh = new Mesh();
        _mesh.name = "Procedural Grid";

        for (int i = 0, y = 0; y <= _ySize; y++)
        {
            for (int x = 0; x <= _xSize; x++, i++)
            {
                _vertices[i] = new Vector3(x, y);
                _uvs[i] = new Vector2(x *1.0f / _xSize, y * 1.0f / _ySize);
                _tangets[i] = tanget;
            }
        }

        _mesh.vertices = _vertices;
        _mesh.uv = _uvs;
        _mesh.tangents = _tangets;

        int[] triangles = new int[_ySize * _xSize * 6];

        for (int ti = 0, vi = 0, y = 0; y < _ySize; y++, vi++)
        {
            for (int x = 0; x < _xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + _xSize + 1;
                triangles[ti + 5] = vi + _xSize + 2;
                _mesh.triangles = triangles;
                _mesh.RecalculateNormals();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (null == _vertices) return;

        Gizmos.color = Color.black;
        foreach (var pos in _vertices)
        {
            Gizmos.DrawSphere(pos, 0.1f);
        }
    }
}