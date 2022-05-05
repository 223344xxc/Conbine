using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Map : MonoBehaviour, DataSaveInterface
{
    private MapSell[][] map; //맵 배열
    private IndexVector mapSize;
    private float sellSize;
    private string mapName;
    private GameObject parent;

    public IndexVector GetMapSize()
    {
        return mapSize;
    }

    public void SetMapSize(IndexVector iv)
    {
        SetMapSize(iv.x, iv.y);
    }
    public void SetMapSize(int x, int y)
    {
        mapSize.Set(x, y);
    }

    public void SetSellSize(float size)
    {
        sellSize = size;
    }

    public float GetSellSize()
    {
        return sellSize;
    }

    public void SetMapName(string name)
    {
        mapName = name;
    }

    public string GetMapName()
    {
        return mapName;
    }

    public void InitMap(IndexVector size)
    {
        InitMap(size.x, size.y);
    }

    public void InitMap(int sizeX, int sizeY)
    {
        ResetMap();

        CreateMap(mapSize);
    }

    public void CreateMap(IndexVector size, float sellSize = 5.5f)
    {
        CreateMap(size.x, size.y, sellSize);
    }

    public void CreateMap(int sizeX, int sizeY, float sellSize = 5.5f)
    {
        parent = GameObject.Find("Map");
    
        SetMapSize(sizeX, sizeY);
        Vector2 offset;
        offset.x = (mapSize.x / 2.0f) * sellSize - (sellSize * 0.5f);
        offset.y = (mapSize.y / 2.0f) * sellSize - (sellSize * 0.5f);

        map = new MapSell[sizeY][];
        for (int y = 0; y < map.Length; y++)
        {
            map[y] = new MapSell[sizeX];
            for (int x = 0; x < map[y].Length; x++)
            {
                GetMap()[y][x] = Instantiate(ResourceManager.GetMapEditorSell(), parent.transform).
                                                                            GetComponent<MapSell>();
                GetMapElement(x, y).SetIndexVector(x, y);
                GetMapElement(x, y).SetPosition(x * sellSize - offset.x, y * -sellSize + offset.y, 1);
            }
        }

    }

    //맵을 초기화 합니다
    public void ResetMap()
    {
        if (map == null)
            return;

        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                map[y][x].RemoveMapSell();
            }
        }

        map = null;
    }

    //입력받은 위치에 상자를 설정합니다
    public void SetOnSquare(int x, int y, bool isOn, SquareCtrl square)
    {
        map[y][x].SetOnSquare(isOn, square);
    }

    //입력한 값에 위치한 셀을 반환합니다
    public MapSell GetMapElement(int x, int y)
    {
        if (map.Length > y && y >= 0 &&
            map[y].Length > x && x >= 0 &&
            map[y][x] != null)
        {
            return map[y][x];
        }
        return null;
    }

    public MapSell[][] GetMap()
    {
        return map;
    }

    #region DataSaveInterface
    public string Save()
    {
        StringBuilder stringBuilder = new StringBuilder();

        for(int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                stringBuilder.Append(SaveManager.ConnectData(SaveManager.DataEndSign.endLine, 
                                                             map[y][x].Save(), ""));
            }
        }

        string saveData = SaveManager.ConnectSaveData(
            SaveManager.ConnectData(SaveManager.DataEndSign.dataNameEnd, 
                                    SaveManager.MapData.mapNameDataName, mapName),
            SaveManager.ConnectData(SaveManager.DataEndSign.dataNameEnd, 
                                    SaveManager.MapData.mapSizeDataName, mapSize.Save()),
            stringBuilder.ToString());
        return saveData;

    }

    public void Load(string str)
    {
        int sellCount = 0;
        string[] fullData = str.SplitToString(SaveManager.DataEndSign.endLine);

        for(int i = 0; i < fullData.Length; i++)
        {
            string[] dataLine = fullData[i].SplitToString(SaveManager.DataEndSign.dataNameEnd);

            if (dataLine[0].CompareTo(SaveManager.MapData.mapNameDataName) == 0)
            {
                mapName = dataLine[1];
            }
            else if(dataLine[0].CompareTo(SaveManager.MapData.mapSizeDataName) == 0)
            {
                mapSize.Load(dataLine[1]);
                InitMap(mapSize);
            }
            else if(dataLine[0].CompareTo(SaveManager.MapData.mapSellDataName) == 0)
            {
                GetMapElement(sellCount % mapSize.x, sellCount / mapSize.x).Load(dataLine[1]);
                sellCount += 1;
            }
        }
    }
    #endregion
}
