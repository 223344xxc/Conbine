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

    /// <summary>
    /// 이펙트를 생성합니다.
    /// </summary>
    /// <param name="effectPrefab"> 생성할 이펙트 프리펩 </param>
    /// <param name="pos"> 이펙트가 생성될 좌표 </param>
    public void CreateEffect(GameObject effectPrefab, Vector3 pos)
    {
        Instantiate(effectPrefab, pos, Quaternion.identity);
    }
    
}
