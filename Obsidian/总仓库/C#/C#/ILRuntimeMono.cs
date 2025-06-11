using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生命周期函数类型
/// </summary>
public enum E_Life_Type
{ 
    OnEnable,
    Start,
    Update,
    FixedUpdate,
    LateUpdate,
    OnDisable,
    OnDestroy,
    //.......
}


public class ILRuntimeMono : MonoBehaviour
{
    public event Action startEvent;
    public event Action updateEvent;
    public event Action onEnableEvent;
    public event Action fixedUpdateEvent;
    public event Action lateUpdateEvent;
    public event Action onDisableEvent;
    public event Action onDestroyEvent;


    private void OnEnable()
    {
        onEnableEvent?.Invoke();
    }

    private void OnDisable()
    {
        onDisableEvent?.Invoke();
    }

    void Start()
    {
        startEvent?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        updateEvent?.Invoke();
    }

    private void FixedUpdate()
    {
        fixedUpdateEvent?.Invoke();
    }

    private void LateUpdate()
    {
        lateUpdateEvent?.Invoke();
    }

    private void OnDestroy()
    {
        onDisableEvent?.Invoke();
    }

    public void AddOrRemoveAction(E_Life_Type type, Action action, bool isAdd = true)
    {
        switch (type)
        {
            case E_Life_Type.OnEnable:
                if (isAdd)
                    onEnableEvent += action;
                else
                    onEnableEvent -= action;
                break;
            case E_Life_Type.Start:
                if (isAdd)
                    startEvent += action;
                else
                    startEvent -= action;
                break;
            case E_Life_Type.Update:
                if (isAdd)
                    updateEvent += action;
                else
                    updateEvent -= action;
                break;
            case E_Life_Type.FixedUpdate:
                if (isAdd)
                    fixedUpdateEvent += action;
                else
                    fixedUpdateEvent -= action;
                break;
            case E_Life_Type.LateUpdate:
                if (isAdd)
                    startEvent += action;
                else
                    startEvent -= action;
                break;
            case E_Life_Type.OnDisable:
                if (isAdd)
                    startEvent += action;
                else
                    startEvent -= action;
                break;
            case E_Life_Type.OnDestroy:
                if (isAdd)
                    startEvent += action;
                else
                    startEvent -= action;
                break;
            default:
                break;
        }
    }
}
