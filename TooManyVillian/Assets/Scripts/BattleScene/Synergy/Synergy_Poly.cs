using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SynergyBase;

public class Synergy_Poly : SynergyBase
{
    protected override void Awake()
    {
        base.Awake();
        mAtivateTime = EActivateTime.Always;
        mType = ESynergyType.Poly;
    }
    public override void AddSynergyCount()
    {
        BuffManager.instance.count_Poly += 1;
    }
}
