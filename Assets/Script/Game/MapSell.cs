﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSellTypeOptions;

public class MapSell : MonoBehaviour, DataSaveInterface
{
    private MapSellType mapType;
    private IndexVector indexVector;
    private bool isOnSquare = false;
    private SquareCtrl onSquare;
    private SpriteRenderer spriteRenderer;
    private ObjectClicker clicker;
    private Animator animator;

    protected virtual void Awake()
    {
        InitMapSell();
    }

    private void InitMapSell()
    {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        clicker = GetComponent<ObjectClicker>();
        if (clicker)
        {
            clicker.BindOnClickDown(() => {
                if (mapType.CompareCode(MapSellType.LOCK_SELL))
                {
                    EffectManager.Instance.CreateEffect(ResourceManager.GetLockOpenEffect(), transform.position);

                    SetAnimationTrigger("PlayLockOpen");

                }

                else if (mapType.CompareCode(MapSellType.LOCK_OPEN_SELL))
                {
                    EffectManager.Instance.CreateEffect(ResourceManager.GetLockOpenEffect(), transform.position);

                    SetAnimationTrigger("PlayLockClose");
                    
                }
            });
        }

        SetSellType(MapSellType.NORMAL_SELL);
    }


    public IndexVector GetIndexVector()
    {
        return indexVector;
    }

    public void SetIndexVector(IndexVector iv)
    {
        indexVector.Set(iv);
    }

    public void SetIndexVector(int x, int y)
    {
        indexVector.Set(x, y);
    }

    public void SetPosition(Vector3 pos)
    {
        SetPosition(pos.x, pos.y, pos.z);
    }

    public void SetPosition(float x, float y, float z)
    {
        transform.localPosition = new Vector3(x, y, z);
    }

    /// <summary>
    /// 애니메이터가 있는지 판단하고 트리거를 실행합니다.
    /// </summary>
    /// <param name="triggerName"> 트리거 이름 </param>
    public void SetAnimationTrigger(string triggerName)
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
    }

    /// <summary>
    /// 자신 위에 있는 상자를 수정합니다.
    /// </summary>
    /// <param name="isOn"> 상자가 위에 있는지 여부 </param>
    /// <param name="square"> 상자 오브젝트 </param>
    public void SetOnSquare(bool isOn, SquareCtrl square = null)
    {
        isOnSquare = isOn;
        onSquare = square;

        if (onSquare)
        {
            onSquare.MoveToPosition(transform.position + new Vector3(0, 0, -10));
            onSquare.SetMapIndex(indexVector);
        }
    }

    /// <summary>
    /// 자신의 위에 있는 상자를 반환합니다.
    /// </summary>
    public SquareCtrl GetOnSquare()
    {
        if (isOnSquare && onSquare)
            return onSquare;
        else
            return null;
    }

    /// <summary>
    /// 자신의 위에 상자가 있는지 여부를 반환합니다.
    /// </summary>
    public bool IsOnSquare()
    {
        return isOnSquare;
    }

    /// <summary>
    /// 상자가 움직일 수 있는지 여부를 반환합니다.
    /// </summary>
    public bool CanMoveThere()
    {
        if (mapType.CanMove() && !isOnSquare)
            return true;
        return false;
    }

    public bool CanOutHere()
    {
        return mapType.CanOut();
    }

    /// <summary>
    /// 자신과 위에있는 상자를 삭제합니다.
    /// </summary>
    public void RemoveMapSell()
    {
        if (onSquare)
            onSquare.RemoveSquare();

        Destroy(gameObject);
    }

    public void RemoveOnSquare()
    {
        if (onSquare)
        {
            onSquare.RemoveSquare();
            SetOnSquare(false);
        }
    }

    /// <summary>
    /// 애니메이션에서 불리는 이벤트 함수입니다.
    /// 타일의 타입을 변경합니다.
    /// </summary>
    /// <param name="typeCode"> 맵 타일 코드</param>
    public void SetSellType_CallAnimation(int typeCode)
    {
        SetSellType(typeCode);
    }

    /// <summary>
    /// 자신의 맵 타일 타입을 변경합니다.
    /// 타입에 따른 수정사항이 실행됩니다.
    /// </summary>
    /// <param name="typeCode"> 맵 타일 코드 </param>
    public void SetSellType(int typeCode, bool isCalculationType = false)
    {
        mapType.SetType(typeCode);

        if (!isCalculationType)
            RefreshSellType();
    }

    /// <summary>
    /// 자신의 맵 타일 타입을 변경합니다.
    /// </summary>
    /// <param name="info"> 타일 정보 </param>
    public void SetSellType(MapSellInfo info)
    {
        SetSellType(info.typeCode, false);
    }

    /// <summary>
    /// 자신의 맵 타일의 애니메이터와 스프라이트 렌더러를 타입 코드에 맞도록 수정합니다.
    /// </summary>
    public void RefreshSellType()
    {
        animator.runtimeAnimatorController = ResourceManager.GetMapSellAnimator(mapType);
        spriteRenderer.color = MapSellType.GetSellColor(mapType.sellTypeCode);
        spriteRenderer.sprite = ResourceManager.GetMapSellSprite(mapType);
    }

    /// <summary>
    /// 상자의 이동 연산에 사용될 자신의 맵 타일의 타입을 변경합니다.
    /// 이 함수로 타입을 변경 할 경우 애니메이터와 스프라이트 렌더러는 변경되지 않습니다.
    /// </summary>
    /// <param name="info"> 맵 타일 코드 </param>
    public void SetCalculationSellType(MapSellInfo info)
    {
        SetSellType(info.typeCode, true);
    }



    public MapSellType GetSellType()
    {
        return mapType;
    }

    #region DataSaveInterface
    public string Save()
    {
        return 
            SaveManager.ConnectData(SaveManager.DataEndSign.endData,
                SaveManager.ConnectData(SaveManager.DataEndSign.dataNameEnd, 
                                       SaveManager.MapData.mapSellDataName, mapType.ToString()),
                SaveManager.ConnectData(SaveManager.DataEndSign.dataNameEnd,
                                        SaveManager.MapData.onSquareDataName, isOnSquare.ToString()));
    }

    public void Load(string str)
    {

        string[] datas = str.SplitToString(SaveManager.DataEndSign.dataNameEnd);

        for(int i = 0; i < datas.Length; i++)
        {
            if (datas[0].CompareTo(SaveManager.MapData.mapSellDataName) == 0)
            {

                SetSellType(int.Parse(datas[1]));
            }
            else if(datas[0].CompareTo(SaveManager.MapData.onSquareDataName) == 0)
            {
                bool onSquare = bool.Parse(datas[1]);

                if (onSquare)
                {
                    isOnSquare = true;
                }
                else
                {
                    isOnSquare = false;
                }
            }
        }

    }
    #endregion
}
