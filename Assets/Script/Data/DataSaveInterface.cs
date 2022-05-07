using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 데이터 저장과 로드를 구현하는 인터페이스 입니다.
/// </summary>
public interface DataSaveInterface
{
    string Save();
    void Load(string str);
}
