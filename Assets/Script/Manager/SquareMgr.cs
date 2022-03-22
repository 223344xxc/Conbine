using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection
{
    None,
    Left, // ←
    Right,// →
    Up,   // ↑
    Down, // ↓
}

public class SquareMgr : MonoBehaviour
{
    public static SquareMgr instance;

    [SerializeField] private GameObject squarePrefab; //임시 변수
    [SerializeField] private List<SquareCtrl> squareList;

    private MapMgr mapMgr;


    private void Awake()
    {
        InitSquareMgr();
    }

    private void InitSquareMgr()
    {
        instance = this;
        squareList = new List<SquareCtrl>();
        mapMgr = GameObject.Find("MapManager").GetComponent<MapMgr>();
    }


    //입력받은 위치에 사각형 생성합니다
    public void SummonSquare(int x, int y)
    {
        SquareCtrl sc = Instantiate(squarePrefab).GetComponent<SquareCtrl>();
        sc.SetListIndex(squareList.Count);
        squareList.Add(sc);
        mapMgr.SetOnSquare(x, y, true, sc);
    }

    //리스트에 있는 상자를 모두 입력받은 방향으로 이동시킵니다
    public void SqaureMove(MoveDirection dir)
    {
        //for(int i = 0; i < squareList.Count; i++)
        //{
        //    squareList[i].GetMapIndex();
        //}

        MapSell ms = mapMgr.FindFinalSell(dir, squareList[0].GetMapIndex());
        
        if (ms)
        {
            mapMgr.SetOnSquare(ms.GetIndexVector(), true, squareList[0]);
        }
    }
}
