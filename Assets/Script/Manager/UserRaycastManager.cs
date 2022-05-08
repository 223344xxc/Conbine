using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserRaycastManager : MonoBehaviour
{
    public static UserRaycastManager instance;

    private RaycastHit2D hitObject;

    private void Awake()
    {
        InitUserRaycastManager();
    }

    private void InitUserRaycastManager()
    {
        instance = this;
    }

    private void Update()
    {
        RaycastUpdate();
    }

    private void RaycastUpdate()
    {
        hitObject = Physics2D.Raycast(
        Camera.main.ScreenToWorldPoint(Input.mousePosition),
        Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public RaycastHit2D GetHitObject()
    {
        return hitObject;
    }
}
