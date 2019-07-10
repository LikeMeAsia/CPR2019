using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public static class MonoBehaviourExtensions 
{
    public static Coroutine CallFuncWait(this MonoBehaviour _Caller, UnityAction action, float delay)
    {
        if (_Caller == null) return null;
        return _Caller.StartCoroutine(ICallFuncWait(action, delay));
    }

    private static IEnumerator ICallFuncWait(UnityAction action, float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        yield return wait;
        if (action != null) { action.Invoke(); }
    }
}
