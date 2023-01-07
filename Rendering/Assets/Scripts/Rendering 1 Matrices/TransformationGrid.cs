using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Assets.Scripts.Rendering_1_Matrices;
using UnityEngine;

public class TransformationGrid : MonoBehaviour
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private int _gridResolution = 10;

    private Transform[] _grids;
    private List<Transformation> _transformations;

    private void Awake()
    {
        _transformations = new List<Transformation>(GetGridPointNum());
        if (null == _grids)
        {
            InitGrids();
        }

        for (int i = 0, y = 0; y < _gridResolution; y++)
        {
            for (int x = 0; x < _gridResolution; x++)
            {
                for (int z = 0; z < _gridResolution; z++, i++)
                {
                    _grids[i] = CreateGridPointBy(x, y, z);
                }
            }
        }
    }

// Update is called once per frame
    void Update()
    {
        for (int i = 0, z = 0; z < _gridResolution; z++)
        {
            for (int y = 0; y < _gridResolution; y++)
            {
                for (int x = 0; x < _gridResolution; x++, i++)
                {
                    _grids[i].localPosition = TransformPointBy(x, y, z); // 更新每一个顶点
                }
            }
        }
    }

    private Matrix4x4 _transfromMatrix;

    // 这里就是根据父物体上的变换组件，对每一个顶点进行变换，得到每个顶点变换后的坐标
    private Vector3 TransformPointBy(int x, int y, int z)
    {
        UpdateTransfromMatrix();

        var position = PerformTransformMatrixBy(x, y, z);
        return position;
    }

    private Vector3 PerformTransformMatrixBy(int x, int y, int z)
    {
        var position = GetPointCoordinatesBy(x, y, z);
        return _transfromMatrix.MultiplyPoint(position);
    }

    private void UpdateTransfromMatrix()
    {
        GetComponents<Transformation>(_transformations);
        if (null == _transformations) return;
        int transCount = _transformations.Count;
        if (transCount <= 0) return;
        _transfromMatrix = _transformations[0].Matrix;
        for (int i = 1; i < transCount; i++)
        {
            _transfromMatrix = _transformations[i].Matrix * _transfromMatrix;
        }
    }

    private Transform CreateGridPointBy(int x, int y, int z)
    {
        var point = GameObject.Instantiate(_prefab);
        point.position = GetPointCoordinatesBy(x, y, z);
        point.GetComponent<MeshRenderer>().material.color = GetColorBy(x, y, z);
        point.SetParent(transform);
        point.gameObject.SetActive(true);

        return point;
    }

    private Color GetColorBy(int x, int y, int z)
    {
        float gridResolutionFloat = _gridResolution;
        var color = new Color(x / gridResolutionFloat, y / gridResolutionFloat, z / gridResolutionFloat);
        return color;
    }

    private Vector3 GetPointCoordinatesBy(int x, int y, int z)
    {
        float center = (_gridResolution - 1) * 0.5f;
        return new Vector3(x - center, y - center, z - center);
    }

    private void InitGrids()
    {
        int gridLen = GetGridPointNum();
        _grids = new Transform[gridLen];
    }

    private int GetGridPointNum()
    {
        return _gridResolution * _gridResolution * _gridResolution;
    }
}