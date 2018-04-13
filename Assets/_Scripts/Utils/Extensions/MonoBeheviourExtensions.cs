using UnityEngine;
using System.Collections;
using System;

public static class MonoBeheviourExtensions
{

    public static Coroutine Invoke(this MonoBehaviour monoBehaviour, Action action, float time)
    {
        return monoBehaviour.StartCoroutine(InvokeImpl(action, time));
    }

    private static IEnumerator InvokeImpl(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    public static Coroutine Invoke<T>(this MonoBehaviour monoBehaviour, Action<T> action, float time, T arg)
    {
        return monoBehaviour.StartCoroutine(InvokeImpl(action, time, arg));
    }

    private static IEnumerator InvokeImpl<T>(Action<T> action, float time, T arg)
    {
        yield return new WaitForSeconds(time);
        action(arg);
    }
}