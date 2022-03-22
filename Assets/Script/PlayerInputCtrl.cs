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
            SquareMgr.instance.SummonSquare(0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SquareMgr.instance.SqaureMove(MoveDirection.Right);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SquareMgr.instance.SqaureMove(MoveDirection.Down);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SquareMgr.instance.SqaureMove(MoveDirection.Left);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SquareMgr.instance.SqaureMove(MoveDirection.Up);
        }
    }
}
