using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;

public class SpawnManager : Singleton<SpawnManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public static ToastInfo SpawnToast(Vector2 position, Transform parent)
    {
        var ToastPopup = Resources.Load<ToastInfo>("Prefabs/Toast");
        ToastInfo t = PoolManager.Pools["Toast"].Spawn(ToastPopup.gameObject, position, Quaternion.identity, parent).GetComponent<ToastInfo>();
        t.transform.localPosition = position;
        return t;
    }

    public static ToastInfo SpawnToast(Transform parent)
    {
        var ToastPopup = Resources.Load<ToastInfo>("Prefabs/Toast");
        ToastInfo t = PoolManager.Pools["Toast"].Spawn(ToastPopup.gameObject, parent).GetComponent<ToastInfo>();
        return t;
    }

    public static void DespawnToast(ToastInfo toast)
    {
        if (PoolManager.Pools["Toast"].IsSpawned(toast.transform))
            PoolManager.Pools["Toast"].Despawn(toast.transform);
    }
}
