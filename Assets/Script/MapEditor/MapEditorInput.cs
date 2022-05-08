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
        for(int i = 0; i < MapSellType.typeNameArray.Length; i++)
        {
            optionData.Add(new Dropdown.OptionData(MapSellType.typeNameArray[i]));
        }
        mapSellTypeDropDown.options = optionData;
    }

    private void Update()
    {
        InputUpdate();
        CursorRayUpdate();
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
    /// 커서 레이 업데이트 함수입니다.
    /// </summary>
    private void CursorRayUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            Camera.main.ScreenToWorldPoint(Input.mousePosition), 
            Camera.main.ScreenToWorldPoint(Input.mousePosition));
       
        
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
                beginClickHitObject.MapSellRelease();
                selectMapSell.Remove(beginClickHitObject);
            }
        }
        if (isClick && EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (hit)
            {
                MapEditorSell mapEditorSell = hit.transform.gameObject.GetComponent<MapEditorSell>();
                if (!mapEditorSell.GetIsSelect())
                {
                    mapEditorSell.MapSellSelect();
                    selectMapSell.Add(mapEditorSell);
                }

            }
            else
            {
                for (int i = 0; i < selectMapSell.Count; i++)
                {
                    selectMapSell[i].MapSellRelease();
                }
                selectMapSell.Clear();
            }
        }
        
    }


    /// <summary>
    /// 맵 사이즈 인풋필드 편집 종료시 호출됩니다.
    /// 인풋필드로 받은 문자열을 inputMapSize 에 변환하여 입력합니다.
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

    public void OnEndEdit_MapSellTypeDropDown()
    {
        for(int i = 0; i < selectMapSell.Count; i++)
        {
            selectMapSell[i].SetSellType(MapSellType.typeCompareArray[mapSellTypeDropDown.value]);
        }
    }

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
