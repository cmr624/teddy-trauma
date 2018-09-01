using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Change me daddy
public class Lever : EnvironmentalObject {

    public bool Pulled { get; private set; }

    public LevelEvent onPulled;
    public LevelEvent onUnpulled;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
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

    protected override void ActOnMovableObject(MovableObject obj)
    {
        TogglePulled();
    }
}

[System.Serializable]
public class LevelEvent : UnityEvent { }