using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : Singleton<MainManager>
{
    [SerializeField]
    private Transform popupPanel;
    
    [SerializeField]
    private Transform toastPos;
    
    /*[SerializeField]
    private int maxToastSpawn;*/

    public List<ToastInfo> toastList;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < maxToastSpawn; i++)
        {
            SpawnToasts();
        }*/
    }

    public void SpawnToasts()
    {
        ToastInfo toastPrefab = SpawnManager.SpawnToast(toastPos.localPosition, popupPanel);
        i++;
        toastPrefab.GetToastCanvas().sortingOrder = i;
        toastPrefab.name = "Toast popup " + i.ToString();
        toastPrefab.GetToastTxt().text = i.ToString();
        if (!toastPrefab.GetToastGO().activeSelf)
        {
            toastPrefab.GetToastGO().SetActive(true);
        }
        StartCoroutine(toastPrefab.TimeCountdownHide());
        StartCoroutine(toastPrefab.TimeCountdownDespawn());
        StartCoroutine(toastPrefab.ICountText());
        toastList.Add(toastPrefab);
    }
}
