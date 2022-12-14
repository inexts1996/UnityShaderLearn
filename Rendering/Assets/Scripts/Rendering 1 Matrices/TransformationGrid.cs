using UnityEngine;

public class TransformationGrid : MonoBehaviour
{
    [SerializeField]
    private Transform _prefab;
    [SerializeField] private int _gridResolution = 10;

    private Transform[] _grids;
    private void Awake()
    {
        if (null == _grids)
        {
            InitGrids();
        }

        for(int i = 0, y = 0; y < _gridResolution; y++)
        {
            for(int x = 0; x < _gridResolution; x++)
            {
                for(int z = 0; z < _gridResolution; z++, i++) 
                {
                    _grids[i] = CreateGridPointBy(x, y, z);
                }
            }
        }
    }

    private Transform CreateGridPointBy(int x, int y, int z)
    {
        var newItem = GameObject.Instantiate(_prefab);
        newItem.position = GetPointCoordinatesBy(x, y, z);
    }

    private Vector3 GetPointCoordinatesBy(int x, int y, int z)
    {

    }

    private void InitGrids()
    {
        int gridLen = GetGridLen();
        _grids = new Transform[gridLen];
    }

    private int GetGridLen()
    {
        return _gridResolution * _gridResolution * _gridResolution;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
