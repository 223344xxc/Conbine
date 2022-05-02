using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Vector2 size; //임시 변수
    [SerializeField] private float sellSize;
    
    [SerializeField] private GameObject sellPrefab;
    private Map map;
    //private MapSell[][] map; //맵 배열
    //private IndexVector mapSize;

    private void Awake()
    {
        InitMapMgr();
    }

    //맵 초기화
    private void InitMapMgr()
    {
        map = new Map();
        
        
        CreateMap(map.GetMapSize().CastIndexVector(size), sellSize);
    }

    //입력받은 맵 사이즈와 셀 사이즈를 기반으로 맵을 생성합니다
    public void CreateMap(IndexVector size, float sellSize)
    {
        map.CreateMap(size, sellSize);
    }

    //맵을 초기화 합니다
    public void ResetMap()
    {
        map.ResetMap();
    }

    //입력받은 위치에 상자를 설정합니다
    public void SetOnSquare(IndexVector iv, bool isOn, SquareCtrl square)
    {
        SetOnSquare(iv.x, iv.y, isOn, square);
    }

    //입력받은 위치에 상자를 설정합니다
    public void SetOnSquare(int x, int y, bool isOn, SquareCtrl square)
    {
        map.SetOnSquare(x, y, isOn, square);
    }

    public Map GetMap()
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
        return map.GetMapElement(x, y);
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
