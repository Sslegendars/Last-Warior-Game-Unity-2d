using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveAnimator : AnimatorController
{
    private const string hitTriggerName = "Hit_Trigger";

    public void TakeHitAnimation()
    {
        SetAnimationTrigger(hitTriggerName);
    }
}
