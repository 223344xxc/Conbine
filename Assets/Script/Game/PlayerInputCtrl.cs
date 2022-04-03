using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputCtrl : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SquareMgr.instance.SummonSquare(3, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SquareMgr.instance.WorldSqaureMove(MoveDirection.Right);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SquareMgr.instance.WorldSqaureMove(MoveDirection.Down);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SquareMgr.instance.WorldSqaureMove(MoveDirection.Left);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SquareMgr.instance.WorldSqaureMove(MoveDirection.Up);
        }
    }
}
