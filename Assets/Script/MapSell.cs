using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapSellType
{
    None, // 기본 타일
}

public class MapSell : MonoBehaviour
{
    [SerializeField] private IndexVector indexVector;

    private void Awake()
    {
        InitMapSell();
    }

    private void InitMapSell()
    {

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
   
}
