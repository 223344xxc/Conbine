using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MapSellTypeOptions;
using UnityEngine.EventSystems;

public class MapEditorInput : MonoBehaviour
{
    private InputField mapSizeInputField;
    private InputField mapNameInputField;
    private Dropdown mapSellTypeDropDown;


    private List<MapEditorSell> selectMapSell;


    private MapEditorSell beginClickHitObject;
    private bool isClick = false;
    private bool isClickDown;
    private bool isClickUp;
    private bool beginObjectisSelect = false;

    private Map nowEditingMap;

    private void Awake()
    {
        InitMapEditorInput();
    }

    private void InitMapEditorInput()
    {
        selectMapSell = new List<MapEditorSell>();
        mapSizeInputField = GameObject.Find("MapSizeInputField").GetComponent<InputField>();
        mapNameInputField = GameObject.Find("MapNameInputField").GetComponent<InputField>();
        mapSellTypeDropDown = GameObject.Find("SellTypeDropDown").GetComponent<Dropdown>();


        List<Dropdown.OptionData> optionData = new List<Dropdown.OptionData>();
        for(int i = 0; i < MapSellType.MAP_SELL_INFO_ARRAY.Length; i++)
        {
            optionData.Add(new Dropdown.OptionData(MapSellType.MAP_SELL_INFO_ARRAY[i].typeName));
        }
        optionData.Add(new Dropdown.OptionData("-"));

        mapSellTypeDropDown.options = optionData;
        mapSellTypeDropDown.SetValueWithoutNotify(mapSellTypeDropDown.options.Count - 1);

    }

    private void Update()
    {
        InputUpdate();
        SelectUpdate();
    }

    public void SetMap(Map map)
    {
        nowEditingMap = map;
    }

    public Map GetMap()
    {
        return nowEditingMap;
    }

    /// <summary>
    /// 사용자의 입력 업데이트 함수입니다.
    /// </summary>
    private void InputUpdate()
    {
        isClick = Input.GetMouseButton(0);
        isClickDown = Input.GetMouseButtonDown(0);
        isClickUp = Input.GetMouseButtonUp(0);
    }

    /// <summary>
    /// 맵 선택 업데이트 함수입니다.
    /// </summary>
    private void SelectUpdate()
    {
        RaycastHit2D hit = UserRaycastManager.instance.GetHitObject();


        if (isClickDown && hit)
        {
            beginClickHitObject = hit.transform.GetComponent<MapEditorSell>();
            beginObjectisSelect = beginClickHitObject.GetIsSelect();
        }
        else if (isClickUp && hit)
        {
            if (beginClickHitObject.gameObject == hit.transform.gameObject && 
                beginClickHitObject.GetIsSelect() &&
                beginObjectisSelect)
            {
                MapSellRelease(beginClickHitObject);
            }
        }
        if (isClick && EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (hit)
            {
                MapEditorSell mapEditorSell = hit.transform.gameObject.GetComponent<MapEditorSell>();
                if (!mapEditorSell.GetIsSelect())
                {
                    MapSellSelect(mapEditorSell);
                }

            }
            else
            {
                for (int i = 0; i < selectMapSell.Count; i++)
                {
                    MapSellRelease(selectMapSell[i]);
                }
            }
        }
        
    }

    /// <summary>
    /// 입력받은 맵 타일을 선택합니다.
    /// </summary>
    /// <param name="sell"> 선택할 타일 </param>
    private void MapSellSelect(MapEditorSell sell)
    {
        sell.MapSellSelect();
        selectMapSell.Add(sell);
        RefreshMapSellTypeDropDown();
    }

    /// <summary>
    /// 입력받은 맵 타일을 선택 해제합니다.
    /// </summary>
    /// <param name="sell"> 선택 해제할 타일 </param>
    private void MapSellRelease(MapEditorSell sell)
    {
        sell.MapSellRelease();
        selectMapSell.Remove(sell);
        RefreshMapSellTypeDropDown();
    }

    /// <summary>
    /// 모든 타일을 선택 해제합니다.
    /// </summary>
    public void ResetSellSelect()
    {
        for (int i = 0; i < selectMapSell.Count; i++)
            MapSellRelease(selectMapSell[i]);

    }

    /// <summary>
    /// 맵 타일 타입 드롭다운을 정리합니다.
    /// </summary>
    private void RefreshMapSellTypeDropDown()
    {
        if(selectMapSell.Count > 0)
        {
            int tempCode = selectMapSell[0].GetSellType().sellTypeCode;

            for(int i = 0; i < selectMapSell.Count; i++)
            {
                if (!selectMapSell[i].GetSellType().CompareCode(tempCode))
                {
                    mapSellTypeDropDown.SetValueWithoutNotify(mapSellTypeDropDown.options.Count - 1);
                    break;
                }

                mapSellTypeDropDown.SetValueWithoutNotify(tempCode);
            }
        }
        else
        {
            mapSellTypeDropDown.SetValueWithoutNotify(mapSellTypeDropDown.options.Count - 1);
        }
    }

    /// <summary>
    /// 맵 사이즈 인풋필드 편집 종료시 호출됩니다.
    /// 인풋필드로 받은 문자열을 nowEditingMap 에 변환하여 입력합니다.
    /// </summary>
    public void OnEndEdit_MapSizeInputField()
    {
        string[] sizeStr = mapSizeInputField.text.Split('/');
        nowEditingMap.SetMapSize(int.Parse(sizeStr[0]), int.Parse(sizeStr[1]));
    }
   
    /// <summary>
    /// 맵 이름 인풋필드 편집 종료시 호출됩니다.
    /// 편집중인 맵 이름을 바꿉니다.
    /// </summary>
    public void OnEndEdit_MapNameInputField()
    {
        nowEditingMap.SetMapName(mapNameInputField.text);
    }

    /// <summary>
    /// 타일 타입 드롭다운 편집 종료시 호출됩니다.
    /// </summary>
    public void OnEndEdit_MapSellTypeDropDown()
    {
        if (!MapSellType.ChackType(mapSellTypeDropDown.value))
            return;

        if (selectMapSell.Count == 0)
            mapSellTypeDropDown.SetValueWithoutNotify(mapSellTypeDropDown.options.Count - 1);

        for(int i = 0; i < selectMapSell.Count; i++)
        {
            selectMapSell[i].SetSellType(MapSellType.MAP_SELL_INFO_ARRAY[mapSellTypeDropDown.value]);
            "changeCall".LogError();
        }

    }

    /// <summary>
    /// 선택된 모든 타일위에 상자를 배치합니다.
    /// </summary>
    public void AddSquareForSelectMapSell()
    {
        for(int i = 0;i < selectMapSell.Count; i++)
        {
            SquareManager.instance.SummonSquare(selectMapSell[i].GetIndexVector());
        }
    }


    /// <summary>
    /// 선택된 모든 타일위에 있는 상자를 제거합니다.
    /// </summary>
    public void RemoveSquareForSelectMapSell()
    {
        for(int i = 0; i < selectMapSell.Count; i++)
        {
            selectMapSell[i].RemoveOnSquare();
        }
    }

    /// <summary>
    /// 편집중인 맵의 사이즈를 반환합니다.
    /// </summary>
    public IndexVector GetInputMapSize()
    {
        return nowEditingMap.GetMapSize();
    }

    /// <summary>
    /// 편집중인 맵의 이름을 반환합니다.
    /// </summary>
    public string GetEditingMapName()
    {
        return nowEditingMap.GetMapName();
    }
}
