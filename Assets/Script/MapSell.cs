using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapSellType
{
    None, // 기본 타일
}

public class MapSell : MonoBehaviour
{
    private IndexVector indexVector;
    private bool isSquareOn = false;
    private SquareCtrl onSquare;

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

    //자신 위에 있는 상자를 수정
    public void SetOnSquare(bool isOn, SquareCtrl square = null)
    {
        isSquareOn = isOn;
        onSquare = square;

        onSquare.transform.position = transform.position - new Vector3(0, 0, transform.position.z);

        square.SetMapIndex(indexVector);
    }
}
