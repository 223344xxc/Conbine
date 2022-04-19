using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : DataSaveInterface
{
    private MapSell[][] map; //맵 배열
    private IndexVector mapSize;
    private float sellSize;
    private string mapName;

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

        SetMapSize(sizeX, sizeY);
        map = new MapSell[sizeY][];
        for(int y = 0; y < map.Length; y++)
        {
            map[y] = new MapSell[sizeX];
            for (int x = 0; x < map[y].Length; x++)
            {
                map[y][x] = new MapSell();
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
        string saveData = SaveManager.ConnectSaveData(
            SaveManager.ConnectData(SaveManager.DataEndSign.dataNameEnd, SaveManager.MapData.mapNameDataName, mapName),
            SaveManager.ConnectData(SaveManager.DataEndSign.dataNameEnd, SaveManager.MapData.mapSizeDataName, mapSize.ToString()));
        return saveData;

    }

    public void Load(string str)
    {

    }
    #endregion
}
