using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCtrl : MonoBehaviour
{
    private int listIndex;          //SquareMgr 에 있는 리스트의 인덱스
    private IndexVector mapIndex;   //MapMgr 에 있는 map 의 인덱스

    private bool isTrakingTarget;
    private Vector3 moveTarget;

    private static float squareSpeed = 150;

    private Animator anim;

    private void Awake()
    {
        InitSquareCtrl();
    }

    private void InitSquareCtrl()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        SquareMoveUpdate();
    }

    //상자의 움직임 업데이트 입니다
    private void SquareMoveUpdate()
    {
        if (isTrakingTarget)
        {
            Vector3 moveDistance = (moveTarget - transform.position).normalized * Time.deltaTime * squareSpeed;

            if (Vector3.SqrMagnitude(moveTarget - transform.position) <= moveDistance.sqrMagnitude)
            {
                transform.position = moveTarget;

                TrakingEnd();
            }
            else
            {
                transform.position += moveDistance;
            }
        }
    }

    //상자가 움직임이 끝나면 실행됩니다
    public void TrakingEnd()
    {
        isTrakingTarget = false;
        anim.SetTrigger("BlockStop");
    }

    public void SetListIndex(int index)
    {
        listIndex = index;
    }
    public int GetListIndex()
    {
        return listIndex;
    }

    public void SetMapIndex(int x, int y)
    {
        mapIndex.Set(x, y);
    }
    public void SetMapIndex(IndexVector iv)
    {
        mapIndex.Set(iv);
    }
    public IndexVector GetMapIndex()
    {
        return mapIndex;
    }

    //상자의 목표 위치를 수정하고 움직입니다
    public void MoveToPosition(Vector3 pos)
    {
        isTrakingTarget = true;
        moveTarget = pos;
    }
    public bool CanMove()
    {
        return !isTrakingTarget;
    }


    //상자가 움직이는 방향에 맞춰 각도를 설정합니다
    public void SetSquareMoveAngle(MoveDirection dir)
    {
        switch (dir)
        {
            case MoveDirection.None:
                break;
            case MoveDirection.Left:
                transform.eulerAngles = new Vector3(0, 0, -90);
                break;
            case MoveDirection.Right:
                transform.eulerAngles = new Vector3(0, 0, 90);
                break;
            case MoveDirection.Up:
                transform.eulerAngles = new Vector3(0, 0, -180);
                break;
            case MoveDirection.Down:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            default:
                break;
        }
    }

    //상자를 삭제합니다
    public void RemoveSquare()
    {
        Destroy(gameObject);
    }
}
