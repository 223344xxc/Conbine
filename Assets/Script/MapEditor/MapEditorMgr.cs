using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorMgr : MonoBehaviour
{
    private MapMgr mapMgr;
    private MapEditorInput mapEditorInput;


    private void Awake()
    {
        InitMapEditorMgr();
    }

    private void InitMapEditorMgr()
    {
        mapMgr = GameObject.Find("MapManager").GetComponent<MapMgr>();
        mapEditorInput = GameObject.Find("MapEditorInput").GetComponent<MapEditorInput>();
    }
    
    //에디터 맵을 다시 그립니다
    public void MapReset()
    {
        mapMgr.ResetMap();
        mapMgr.CreateMap(mapEditorInput.GetInputMapSize(), 4.5f);
    }

    //맵을 저장합니다
    public void SaveMap()
    {
        SaveMgr.WriteText(FilePathMgr.GetMapDataPath(mapEditorInput.GetEditingMapName()),
            SaveMgr.ConnectSaveData(mapEditorInput.GetEditingMapName(), 
                                    mapEditorInput.GetInputMapSize().ToString()));
    }

    public void ReadMap()
    {
        SaveMgr.ReadText(FilePathMgr.GetMapDataPath(mapEditorInput.GetEditingMapName())).Log();
    }
}
