using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    None, //기본 플레이 상태
    Pause,//일시정지 상태
}

public class GameMgr : MonoBehaviour
{
    private void Awake()
    {
        InitGameMgr();
    }

    private void InitGameMgr()
    {

    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
