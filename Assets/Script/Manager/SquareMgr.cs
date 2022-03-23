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
        //for (int i = 0; i < squareList.Count; i++)
        //{

        //    MapSell ms = mapMgr.FindFinalSell(dir, squareList[i].GetMapIndex());

        //    if (ms)
        //    {

        //        mapMgr.GetMapElement(squareList[i].GetMapIndex()).SetOnSquare(false);
        //        mapMgr.SetOnSquare(ms.GetIndexVector(), true, squareList[i]);
        //        squareList[i].SetSquareMoveAngle(dir);
        //    }
        //}

        MapSell[][] map = mapMgr.GetMap();

        switch (dir)
        {
            case MoveDirection.None:
                break;

            case MoveDirection.Left:
                for (int y = 0; y < map.Length; y++)
                {
                    for (int x = 0; x > map[y].Length; x++)
                    {
                        SquareCtrl sc = mapMgr.GetMapElement(x, y).GetOnSquare();
                        //if ()


                    }
                }
                break;

            case MoveDirection.Right:
                for (int y = 0; y < map.Length; y++)
                {
                    for (int x = map[y].Length - 1; x >= 0; x--)
                    {

                    }
                }
                break;

            case MoveDirection.Up:

                break;

            case MoveDirection.Down:

                break;

            default:
                break;
        }
    }
}
