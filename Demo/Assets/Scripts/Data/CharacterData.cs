using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    //기본 캐릭터 데이터
    [SerializeField] CharacterBaseSO m_CharacterBaseData;
    //강화 관련 변수
    [SerializeField] uint m_TimeEducated = 0;
    [SerializeField] uint m_TimeBrainwashed = 0;
    [SerializeField] bool m_canPromote = true;
    [SerializeField] uint m_TimeGot = 0;

    GameObject m_PreviewInstance;

    public GameObject PreviewInstance { get { return m_PreviewInstance; } set { m_PreviewInstance = value; } }
    public CharacterBaseSO CharacterBaseData => m_CharacterBaseData;


}
