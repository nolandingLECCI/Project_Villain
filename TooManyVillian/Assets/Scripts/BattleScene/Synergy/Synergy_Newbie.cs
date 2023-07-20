using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synergy_Newbie : SynergyBase
{
    protected override void Awake()
    {
        base.Awake();
        mAtivateTime = EActivateTime.Always;
        mType = ESynergyType.Newbie;
    }
    public override void AddSynergyCount()
    {
        BuffManager.instance.count_Newbie += 1;
    }
}
