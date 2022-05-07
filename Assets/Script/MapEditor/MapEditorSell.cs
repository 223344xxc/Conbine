using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorSell : MapSell
{
    private bool isSelect = false;
    SpriteRenderer selectSpriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        InitMapEditorSell();
    }

    public void InitMapEditorSell()
    {
        selectSpriteRenderer = transform.Find("SelectSprite").GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 셀을 클릭시 실행됩니다.
    /// </summary>
    public bool MapSellClick()
    {
        if (isSelect)
            MapSellRelease();
        else
            MapSellSelect();

        return isSelect;
    }

    /// <summary>
    /// 맵이 선택됐을때 실행됩니다.
    /// </summary>
    public void MapSellSelect()
    {
        isSelect = true;
        selectSpriteRenderer.enabled = true;
    }

    /// <summary>
    /// 맵이 선택 해제됐을때 실행됩니다.
    /// </summary>
    public void MapSellRelease()
    {
        isSelect = false;
        selectSpriteRenderer.enabled = false;
    }
    public bool GetIsSelect()
    {
        return isSelect;
    }
}
