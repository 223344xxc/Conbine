using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapEditorInput : MonoBehaviour
{
    private InputField mapSizeInputField;
    private InputField mapNameInputField;

    private IndexVector inputMapSize;
    private List<MapEditorSell> selectMapSell;


    private MapEditorSell beginClickHitObject;
    private bool isClick = false;
    private bool isClickDown;
    private bool isClickUp;
    private bool beginObjectisSelect = false;

    private void Awake()
    {
        InitMapEditorInput();
    }

    private void InitMapEditorInput()
    {
        selectMapSell = new List<MapEditorSell>();
        mapSizeInputField = GameObject.Find("MapSizeInputField").GetComponent<InputField>();
        mapNameInputField = GameObject.Find("MapNameInputField").GetComponent<InputField>();
    }

    private void Update()
    {
        InputUpdate();
        CursorRayUpdate();
    }

    //사용자의 입력 업데이트 함수입니다
    private void InputUpdate()
    {
        isClick = Input.GetMouseButton(0);
        isClickDown = Input.GetMouseButtonDown(0);
        isClickUp = Input.GetMouseButtonUp(0);
    }

    //커서 레이 업데이트 함수입니다
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
            }
        }
        if (isClick)
        {
            if (hit)
            {
                MapEditorSell mapEditorSell = hit.transform.gameObject.GetComponent<MapEditorSell>();
                mapEditorSell.MapSellSelect();
                selectMapSell.Add(mapEditorSell);

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


    //맵 사이즈 인풋필드 편집 종료시 호출됩니다
    //인풋필드로 받은 문자열을 inputMapSize 에 변환하여 입력합니다
    public void OnEndEdit_MapSizeInputField()
    {
        string[] sizeStr = mapSizeInputField.text.Split('/');
        inputMapSize.Set(int.Parse(sizeStr[0]), int.Parse(sizeStr[1]));
    }
   
    
    public IndexVector GetInputMapSize()
    {
        return inputMapSize;
    }

    //편집중인 맵의 이름을 반환합니다
    public string GetEditingMapName()
    {
        return mapNameInputField.text;
    }
}
