using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SynergyBase;

public class Synergy_Partner : SynergyBase
{
    protected override void Awake()
    {
        base.Awake();
        mAtivateTime = EActivateTime.Always;
        mType = ESynergyType.Partner;
    }
    public override void AddSynergyCount()
    {
        BuffManager.instance.count_Partner += 1;
    }
}
