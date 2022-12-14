using UnityEngine;
using System.Collections;
using TMPro;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
    [SerializeField] private int _xSize;
    [SerializeField] private int _ySize;

    private void Awake()
    {
        GnerateGameObject();
    }

    private void GnerateGameObject()
    {
        GnerateMesh();
        GnerateVertices();
        GnerateTriangles();
        GnerateUV();
        GnerateTangents();
        UpdateMesh();
    }

    private Vector4[] _tangents;
    private Vector4 _tangent = new Vector4(1f, 0f, 0f, 0f);

    private void GnerateTangents()
    {
        if (null == _tangents)
        {
            InitTangents();
        }

        for (int i = 0, y = 0;  y <= _ySize; y++)
        {
            for (int x = 0; x <= _xSize; x++, i++)
            {
                _tangents[i] = _tangent;
            } 
        }
    }

    private void InitTangents()
    {
        int tangentCount = GetTangentCount();
        _tangents = new Vector4[tangentCount];
    }

    private int GetTangentCount()
    {
        return GetVerticesCount();
    }

    private Vector2[] _uv;

    private void GnerateUV()
    {
        if (null == _uv)
        {
            InitUV();
        }

        float xSizef = _xSize * 1f;
        float ySizef = _ySize * 1f;
        for (int i = 0, y = 0; y <= _ySize; y++)
        {
            for (int x = 0; x <= _xSize; x++, i++)
            {
                _uv[i] = new Vector2(x / xSizef, y / ySizef);
            }
        }
    }

    private void InitUV()
    {
        int uvSize = GetUVSize();
        _uv = new Vector2[uvSize];
    }

    private int GetUVSize()
    {
        return GetVerticesCount();
    }

    private void GnerateTriangles()
    {
        if (null == _triangles)
        {
            InitTriangles();
        }

        for (int ti = 0, vi = 0, y = 0; y < _ySize; y++, vi++)
        {
            for (int x = 0; x < _xSize; x++, ti += 6, vi++)
            {
                _triangles[ti] = vi;
                _triangles[ti + 1] = vi + _xSize + 1;
                _triangles[ti + 2] = vi + 1;
                _triangles[ti + 3] = vi + 1;
                _triangles[ti + 4] = vi + _xSize + 1;
                _triangles[ti + 5] = vi + _xSize + 2;
            }
        }
    }

    private void InitTriangles()
    {
        int triangleSize = GetTriangleVerticeCount();
        _triangles = new int[triangleSize];
    }

    private int GetTriangleVerticeCount()
    {
        return _xSize * _ySize * 6;
    }

    private void UpdateMesh()
    {
        if (null == _mesh) return;
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        _mesh.RecalculateNormals();
        _mesh.uv = _uv;
        _mesh.tangents = _tangents;
    }

    private Mesh _mesh;

    private void GnerateMesh()
    {
        _mesh = new Mesh();
        _mesh.name = "Procedural Grid";
        GetComponent<MeshFilter>().mesh = _mesh;
    }

    [SerializeField] private Vector3[] _vertices;
    private int[] _triangles;

    private void GnerateVertices()
    {
        int verticesCount = GetVerticesCount();
        _vertices = new Vector3[verticesCount];

        for (int i = 0, y = 0; y <= _ySize; y++)
        {
            for (int x = 0; x <= _xSize; x++, i++)
            {
                _vertices[i] = new Vector3(x, y);
            }
        }
    }

    private int GetVerticesCount()
    {
        return (_xSize + 1) * (_ySize + 1);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDrawGizmos()
    {
        if (null == _vertices) return;

        Gizmos.color = Color.black;
        for (int i = _vertices.Length - 1; i > -1; i--)
        {
            Gizmos.DrawSphere(_vertices[i], 0.1f);
        }
    }
}