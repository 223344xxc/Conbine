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
    
    [SerializeField] private bool isEditor = false;

    private void Awake()
    {
        InitGameMgr();
    }

    private void InitGameMgr()
    {
        instance = this;
    }

    public bool IsEditing()
    {
        return isEditor;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
