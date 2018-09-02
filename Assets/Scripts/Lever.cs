using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : InteractiveObject {

    public bool Pulled { get; private set; }

    public LevelEvent onPulled;
    public LevelEvent onUnpulled;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
    }

    void TogglePulled()
    {
        Pulled = !Pulled;

        Debug.Log("Level is pullled: " + Pulled);

        if (Pulled)
        {
            onPulled.Invoke();
        } else
        {
            onUnpulled.Invoke();
        }
    }

    protected override void Interact()
    {
        TogglePulled();
    }
}

[System.Serializable]
public class LevelEvent : UnityEvent { }