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

    //셀을 클릭시 실행됩니다
    public bool MapSellClick()
    {
        if (isSelect)
            MapSellRelease();
        else
            MapSellSelect();

        return isSelect;
    }

    //맵이 선택됬을때 실행됩니다
    public void MapSellSelect()
    {
        isSelect = true;
        selectSpriteRenderer.enabled = true;
    }

    //맵이 선택 해제됬을때 실행됩니다
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
