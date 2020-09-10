using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public void Awake()
    {
        current = this;
    }

    public event Action onMoving;
    public void Moving()
    {
        if (onMoving != null)
            onMoving();
    }

    public event Action onCallExample;
    public void CallExample()
    {
        if (onCallExample != null)
            onCallExample();
    }
}
