using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private string loadMapName; //임시 변수
    [SerializeField] private float sellSize;
    
    [SerializeField] private GameObject sellPrefab;
    private Map map;

    private void Awake()
    {
        InitMapMgr();
    }

    /// <summary>
    /// 맵 초기화
    /// </summary>
    private void InitMapMgr()
    {
        map = new Map();


        LoadMap(loadMapName);
    }


    /// <summary>
    /// 입력받은 맵 사이즈와 셀 사이즈를 기반으로 맵을 생성합니다.
    /// </summary>
    /// <param name="size"> 맵 사이즈 </param>
    /// <param name="sellSize"> 셀 사이즈 </param>
    public void CreateMap(IndexVector size, float sellSize)
    {
        map.CreateMap(size, sellSize);
    }

    /// <summary>
    /// 맵을 초기화 합니다.
    /// </summary>
    public void ResetMap()
    {
        map.ResetMap();
    }

    /// <summary>
    /// 입력받은 위치에 상자를 설정합니다.
    /// </summary>
    /// <param name="iv"> 상자를 설정할 위치 </param>
    /// <param name="isOn"> 상자가 있는지 여부 </param>
    /// <param name="square"> 상자 객체 </param>
    public void SetOnSquare(IndexVector iv, bool isOn, SquareCtrl square)
    {
        SetOnSquare(iv.x, iv.y, isOn, square);
    }

    /// <summary>
    /// 입력받은 위치에 상자를 설정합니다.
    /// </summary>
    /// <param name="isOn"> 상자가 있는지 여부 </param>
    /// <param name="square"> 상가 객체 </param>
    public void SetOnSquare(int x, int y, bool isOn, SquareCtrl square)
    {
        map.SetOnSquare(x, y, isOn, square);
    }

    public Map GetMap()
    {
        return map;
    }

    /// <summary>
    /// 입력한 값에 위치한 셀을 반환합니다.
    /// </summary>
    /// <param name="iv"> 인덱스 위치 </param>
    public MapSell GetMapElement(IndexVector iv)
    {
        return GetMapElement(iv.x, iv.y);
    }

    /// <summary>
    /// 입력한 값에 위치한 셀을 반환합니다.
    /// </summary>
    public MapSell GetMapElement(int x, int y)
    {
        return map.GetMapElement(x, y);
    }

    /// <summary>
    /// 입력한 벡터에서 입력한 방향으로의 가장 끝 셀을 찾습니다.
    /// </summary>
    /// <param name="dir"> 추적할 방향 </param>
    /// <param name="iv"> 추적을 시작할 기준 위치 </param>
    public MapSell FindFinalSell(MoveDirection dir, IndexVector iv)
    {
        IndexVector nextIv = iv + IndexVector.GetMoveDirectionToIndexVector(dir);
        if (GetMapElement(nextIv) != null && GetMapElement(nextIv).CanMoveThere())
        {
            return FindFinalSell(dir, nextIv);
        }
        return GetMapElement(iv);
    }

    public void LoadMap(string mapName)
    {
        map.Load(SaveManager.ReadText(FilePathManager.GetMapDataPath(mapName)));
    }
}
