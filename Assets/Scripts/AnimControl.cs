using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    public Animator _anim;

    [SerializeField] private TriggerInteract[] triggerInteracts;

    void ResetTrigger()
    {
        foreach(TriggerInteract trigger in triggerInteracts)
        {
            trigger.ResetAnim();
        }
    }
}
