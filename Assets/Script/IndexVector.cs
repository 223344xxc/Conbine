using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct IndexVector
{
    public int x;
    public int y;

    public void CastIndexVector(Vector2 v)
    {
        x = (int)v.x;
        y = (int)v.y;
    }
}
