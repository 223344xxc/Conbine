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
    private GameState state;
    private MapManager mapManager;
    private GlobalGameManager globalGameManager;

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
        mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
        globalGameManager = GameObject.Find("GlobalGameManager").GetComponent<GlobalGameManager>();
    }

    /// <summary>
    /// 게임 시작시 호출됩니다.
    /// </summary>
    private void GameStart()
    {
        mapManager.GameStart();
        state = GameState.None;
    }

    /// <summary>
    /// 돌아가기 버튼 클릭시 호출됩니다.
    /// 메인 씬으로 돌아갑니다.
    /// </summary>
    public void ReturnGame()
    {
        globalGameManager.LoadMainScene();
    }
}
