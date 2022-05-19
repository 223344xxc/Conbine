using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    None, //기본 플레이 상태
    Pause,//일시정지 상태
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool isEditor = false;

    private GameState state;
    private MapManager mapManager;

    private void Awake()
    {
        InitGameMgr();
    }

    private void Start()
    {
        GameStart();
    }

    private void InitGameMgr()
    {
        instance = this;

        mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
    }

    private void GameStart()
    {
        mapManager.GameStart();
        state = GameState.None;
    }

    public bool IsEditing()
    {
        return isEditor;
    }
}
