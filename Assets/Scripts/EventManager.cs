using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public Action OnContentType;
    public Action OnMassType;
    public Action OnRemainingType;
    public static EventManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void ContentType()
    {
        OnContentType?.Invoke();
    }
    public void MassType()
    {
        OnMassType?.Invoke();
    }
    public void RemainingType()
    {
        OnRemainingType?.Invoke();
    }
}
