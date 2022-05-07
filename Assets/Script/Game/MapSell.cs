using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSellTypeOptions;

public class MapSell : MonoBehaviour, DataSaveInterface
{
    private MapSellType mapType;
    private IndexVector indexVector;
    private bool isSquareOn = false;
    private SquareCtrl onSquare;
    private SpriteRenderer spriteRenderer;


    protected virtual void Awake()
    {
        InitMapSell();
    }

    private void InitMapSell()
    {
        mapType.SetType(MapSellType.Normal);
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    /// 자신 위에 있는 상자를 수정합니다.
    /// </summary>
    /// <param name="isOn"> 상자가 위에 있는지 여부 </param>
    /// <param name="square"> 상자 오브젝트 </param>
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

    /// <summary>
    /// 자신의 위에 있는 상자를 반환합니다.
    /// </summary>
    public SquareCtrl GetOnSquare()
    {
        if (isSquareOn && onSquare)
            return onSquare;
        else
            return null;
    }

    /// <summary>
    /// 상자가 움직일 수 있는지 여부를 반환합니다.
    /// </summary>
    public bool CanMoveThere()
    {
        if (mapType.CompareCode(MapSellType.Normal) && !isSquareOn)
            return true;
        return false;
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


    // (test) 변경한 타입에 따라 스프라이트 혹은 색을 변경합니다
    /// <summary>
    /// 자신의 맵 타일 타입을 변경합니다.
    /// 타입에 따른 수정사항이 실행됩니다.
    /// </summary>
    /// <param name="typeCode"> 맵 타일 코드 </param>
    public void SetSellType(int typeCode)
    {
        mapType.SetType(typeCode);

        switch (mapType.sellTypeCode)
        {
            case MapSellType.Normal:
                spriteRenderer.color = new Color(0, 0.56f, 0.56f, 1.0f); //임시 색상
                break;

            case MapSellType.Transparency:
                spriteRenderer.color = new Color(0, 0.56f, 0.56f, 0.0f); //임시 색상
                break;

            case MapSellType.Wall:
                spriteRenderer.color = new Color(0.3f, 0.3f, 0.3f); //임시 색상
                break;

            default:
                spriteRenderer.color = new Color(1, 1, 1);
                break;
        }
    }

    #region DataSaveInterface
    public string Save()
    {
        return SaveManager.ConnectData(SaveManager.DataEndSign.dataNameEnd, 
                                       SaveManager.MapData.mapSellDataName, mapType.ToString());
    }

    public void Load(string str)
    {
        SetSellType(int.Parse(str));
    }
    #endregion
}
