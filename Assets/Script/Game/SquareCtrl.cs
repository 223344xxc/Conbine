﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SquareCtrl : MonoBehaviour
{
    /// <summary>
    /// SquareMgr 에 있는 리스트의 인덱스 입니다.
    /// </summary>
    private int listIndex;          

    /// <summary>
    /// MapMgr 에 있는 map 의 인덱스 입니다.
    /// </summary>
    private IndexVector mapIndex; 

    private bool isTrakingTarget;
    private Vector3 moveTarget;

    private static float squareSpeed = 120;

    private Animator anim;

    private Action trakingEndAction;


    private void Awake()
    {
        InitSquareCtrl();
        ResetTrakingEndAction();
    }

    private void InitSquareCtrl()
    {
        anim = GetComponent<Animator>();


        SetTrakingEndAction(() => { anim.SetTrigger("BlockStop"); });
    }

    private void Start()
    {
    }

    private void Update()
    {
        SquareMoveUpdate();
    }

    /// <summary>
    /// 상자의 움직임 업데이트 함수 입니다.
    /// </summary>
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

    /// <summary>
    /// 상자의 움직임이 끝나면 실행되는 함수 입니다.
    /// </summary>
    public void TrakingEnd()
    {
        isTrakingTarget = false;


        trakingEndAction?.Invoke();
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

    /// <summary>
    /// 상자의 목표 위치를 수정하고 움직입니다.
    /// </summary>
    /// <param name="pos"> 목표 좌표 </param>
    public void MoveToPosition(Vector3 pos)
    {
        isTrakingTarget = true;
        moveTarget = pos;
    }

    /// <summary>
    /// 상자가 지금 움직이고 있는지 여부를 반환합니다.
    /// </summary>
    public bool CanMove()
    {
        return !isTrakingTarget;
    }


    /// <summary>
    /// 상자가 움직이는 방향에 맞춰 각도를 설정합니다.
    /// </summary>
    /// <param name="dir"> 상자의 방향 </param>
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

    /// <summary>
    /// 상자의 움직임이 끝날때 실행될 이벤트를 설정합니다.
    /// </summary>
    public void SetTrakingEndAction(Action action)
    {
        trakingEndAction = action;
    }

    /// <summary>
    /// 상자의 움직임이 끝날때 실행될 이벤트를 추가합니다.
    /// </summary>
    public void AddTrakingEndAction(Action action)
    {
        trakingEndAction += action;
    }

    /// <summary>
    /// 상자의 움직임 종료 이벤트를 초기화 합니다.
    /// </summary>
    public void ResetTrakingEndAction()
    {
        SetTrakingEndAction(() =>
        {
            SetAnimatorTrigger("BlockStop");
        });
    }

    /// <summary>
    /// 상자의 입력받은 애니메이션 트리거를 작동시킵니다.
    /// </summary>
    public void SetAnimatorTrigger(string triggerName)
    {
        anim.SetTrigger(triggerName);
    }

    /// <summary>
    /// 상자를 삭제합니다.
    /// </summary>
    public void RemoveSquare()
    {
        Destroy(gameObject);
    }
}
