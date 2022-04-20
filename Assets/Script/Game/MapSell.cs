﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapSellType
{
    None,   //투명 블럭
    Normal, //기본 블럭
}

public class MapSell : MonoBehaviour, DataSaveInterface
{
    [SerializeField] private MapSellType mapType;
    private IndexVector indexVector;
    private bool isSquareOn = false;
    private SquareCtrl onSquare;

    protected virtual void Awake()
    {
        InitMapSell();
    }

    private void InitMapSell()
    {
        mapType = MapSellType.Normal;
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

    //자신 위에 있는 상자를 수정합니다
    public void SetOnSquare(bool isOn, SquareCtrl square = null)
    {
        isSquareOn = isOn;
        onSquare = square;

        if (onSquare)
        {
            onSquare.MoveToPosition(transform.position + new Vector3(0, 0, -10));
            onSquare.SetMapIndex(indexVector);
        }
    }

    //자신의 위에 있는 상자를 반환합니다
    public SquareCtrl GetOnSquare()
    {
        if (isSquareOn && onSquare)
            return onSquare;
        else
            return null;
    }


    public void SetMapType(MapSellType type)
    {
        mapType = type;
    }


    //상자가 움직일수 있는지 여부를 반환합니다
    public bool CanMoveThere()
    {
        if (mapType == MapSellType.Normal && !isSquareOn)
            return true;
        return false;
    }

    //자신과 위에있는 상자를 삭제합니다
    public void RemoveMapSell()
    {
        if (onSquare)
            onSquare.RemoveSquare();

        Destroy(gameObject);
    }

    #region DataSaveInterface
    public string Save()
    {
        return "";
    }

    public void Load(string str)
    {

    }
    #endregion
}