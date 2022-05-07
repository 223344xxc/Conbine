using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteEffectComponent : MonoBehaviour
{
    private Animator animator;


    /// <summary>
    /// 이펙트가 자식 오브젝트라면 최상위 오브젝트를 연결해야 합니다.
    /// </summary>
    [SerializeField] private GameObject effectBody;

    private void Awake()
    {
        InitSpriteEffectComponent();
    }

    private void InitSpriteEffectComponent()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// 이펙트를 삭제합니다.
    /// 최상위 오브젝트가 있다면 그것을, 없다면 이펙트만 삭제합니다.
    /// </summary>
    public void DeleteEffect()
    {
        if (effectBody)
        {
            Destroy(effectBody);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
