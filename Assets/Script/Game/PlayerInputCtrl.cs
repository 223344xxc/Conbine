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
            SquareManager.instance.SummonSquare(3, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SquareManager.instance.WorldSqaureMove(MoveDirection.Right);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SquareManager.instance.WorldSqaureMove(MoveDirection.Down);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SquareManager.instance.WorldSqaureMove(MoveDirection.Left);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SquareManager.instance.WorldSqaureMove(MoveDirection.Up);
        }
    }
}
