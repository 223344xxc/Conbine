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

    //입력받은 상자를 이동시킵니다
    public void SquareMove(MoveDirection dir, SquareCtrl square)
    {
        if (square)
        {
            MapSell ms = mapMgr.FindFinalSell(dir, square.GetMapIndex());

            if (ms)
            {
                mapMgr.GetMapElement(square.GetMapIndex()).SetOnSquare(false);
                mapMgr.SetOnSquare(ms.GetIndexVector(), true, square);
                square.SetSquareMoveAngle(dir);
            }
        }
    }

    //리스트에 있는 상자를 모두 입력받은 방향으로 이동시킵니다
    public bool WorldSqaureMove(MoveDirection dir)
    {
        for(int i = 0; i < squareList.Count; i++)
        {
            if (!squareList[i].CanMove())
            {
                return false;
            }
        }

        MapSell[][] map = mapMgr.GetMap().GetMap();

        switch (dir)
        {
            case MoveDirection.None:
                break;

            case MoveDirection.Left:
                for (int y = 0; y < map.Length; y++)
                {
                    for (int x = 0; x < map[y].Length; x++)
                    {
                        SquareMove(dir, mapMgr.GetMapElement(x, y).GetOnSquare());
                    }
                }
                break;

            case MoveDirection.Right:
                for (int y = 0; y < map.Length; y++)
                {
                    for (int x = map[y].Length - 1; x >= 0; x--)
                    {
                        SquareMove(dir, mapMgr.GetMapElement(x, y).GetOnSquare());
                    }
                }
                break;

            case MoveDirection.Up:
                for (int y = 0; y < map.Length; y++)
                {
                    for (int x = 0; x < map[y].Length; x++)
                    {
                        SquareMove(dir, mapMgr.GetMapElement(x, y).GetOnSquare());
                    }
                }
                break;

            case MoveDirection.Down:
                for (int y = map.Length - 1; y >= 0; y--)
                {
                    for (int x = 0; x < map[y].Length; x++)
                    {
                        SquareMove(dir, mapMgr.GetMapElement(x, y).GetOnSquare());
                    }
                }
                break;

            default:
                break;
        }
        return true;
    }
}
