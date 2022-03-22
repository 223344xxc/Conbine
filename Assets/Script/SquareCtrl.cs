using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCtrl : MonoBehaviour
{
    private int listIndex;          //SquareMgr 에 있는 리스트의 인덱스
    private IndexVector mapIndex;   //MapMgr 에 있는 map 의 인덱스


    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void SetListIndex(int index)
    {
        listIndex = index;
    }
    public int GetListIndex()
    {
        return listIndex;
    }

    public void SetMapIndex(int x, int y)
    {
        mapIndex.Set(x, y);
    }
    public void SetMapIndex(IndexVector iv)
    {
        mapIndex.Set(iv);
    }
    public IndexVector GetMapIndex()
    {
        return mapIndex;
    }
}
