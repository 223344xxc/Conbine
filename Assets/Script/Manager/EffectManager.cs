using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private static EffectManager instance;
    public static EffectManager Instance
    {
        get
        {
            if (instance == null)
                instance = new EffectManager();

            return instance;
        }
    }

    public void CreateEffect(GameObject effectPrefab, Vector3 pos)
    {
        Instantiate(effectPrefab, pos, Quaternion.identity);
    }
    
}
