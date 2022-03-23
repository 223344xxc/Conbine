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

    //맵 초기화
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
                map[y][x].SetIndexVector(x, y);
                map[y][x].transform.position = new Vector3(x * sellSize - offset.x, y * - sellSize + offset.y, mapParent.transform.position.z);
            }
        }
    }

    //입력받은 위치에 상자를 설정합니다
    public void SetOnSquare(IndexVector iv, bool isOn, SquareCtrl square)
    {
        SetOnSquare(iv.x, iv.y, isOn, square);
    }

    public void SetOnSquare(int x, int y, bool isOn, SquareCtrl square)
    {
        map[y][x].SetOnSquare(isOn, square);
    }

    public MapSell[][] GetMap()
    {
        return map;
    }

    //입력한 값에 위치한 셀을 반환합니다
    public MapSell GetMapElement(IndexVector iv)
    {
        return GetMapElement(iv.x, iv.y);
    }

    //입력한 값에 위치한 셀을 반환합니다
    public MapSell GetMapElement(int x, int y)
    {
        if(map.Length > y && y >= 0 &&
            map[y].Length > x && x >= 0 &&
            map[y][x] != null)
        {
            return map[y][x];
        }

        return null;
    }

    //입력한 벡터에서 입력한 방향으로의 가장끝 셀을 찾습니다
    public MapSell FindFinalSell(MoveDirection dir, IndexVector iv)
    {
        IndexVector nextIv = iv + IndexVector.GetMoveDirectionToIndexVector(dir);
        if (GetMapElement(nextIv) != null && GetMapElement(nextIv).CanMoveThere())
        {
            return FindFinalSell(dir, nextIv);
        }
        return GetMapElement(iv);

    }
}
