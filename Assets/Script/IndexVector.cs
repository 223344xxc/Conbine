using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct IndexVector
{
    public int x;
    public int y;



    public IndexVector(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public IndexVector(IndexVector iv)
    {
        this.x = iv.x;
        this.y = iv.y;
    }

    
    public void Set(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public void Set(IndexVector iv)
    {
        this.x = iv.x;
        this.y = iv.y;
    }
    

    public void CastIndexVector(float x, float y)
    {
        this.x = (int)x;
        this.y = (int)y;
    }
    public void CastIndexVector(Vector2 v)
    {
        this.x = (int)v.x;
        this.y = (int)v.y;
    }

    public static IndexVector operator + (IndexVector iv1, IndexVector iv2)
    {
        return new IndexVector(iv1.x + iv2.x, iv1.y + iv2.y);
    }

    public static IndexVector operator - (IndexVector iv1, IndexVector iv2)
    {
        return new IndexVector(iv1.x - iv2.x, iv1.y - iv2.y);
    }
}
