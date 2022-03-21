using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr : MonoBehaviour
{
    [SerializeField] private Vector2 size; //임시 변수

    [SerializeField] private float sellSize;
    [SerializeField] private MapSell[][] map;
    [SerializeField] private GameObject sellPrefab;
    private GameObject mapParent;

    private IndexVector mapSize;

    private void Awake()
    {
        InitMapMgr();
    }

    private void InitMapMgr()
    {
        mapParent = GameObject.Find("Map");

        mapSize.CastIndexVector(size);

        Vector2 offset;
        offset.x = (size.x / 2) * sellSize - (sellSize * 0.5f);
        offset.y = (size.y / 2) * sellSize - (sellSize * 0.5f);


        map = new MapSell[mapSize.y][];
        for(int y = 0; y < mapSize.y; y++)
        {
            map[y] = new MapSell[mapSize.x];
            for(int x = 0; x < mapSize.x; x++)
            {
                map[y][x] = Instantiate(sellPrefab, mapParent.transform).GetComponent<MapSell>();
                map[y][x].transform.position = new Vector2(x * sellSize - offset.x, y * - sellSize + offset.y);
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
