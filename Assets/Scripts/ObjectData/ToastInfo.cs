using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastInfo : MonoBehaviour
{
    [SerializeField]
    private Canvas toastCanvas;

    [SerializeField]
    private GameObject toastGO;
    
    [SerializeField]
    private Text toastTxt;
    
    [SerializeField]
    private int showTime;
    
    [SerializeField]
    private int lifespanTime;

    int i = 1;
    public Text GetToastTxt()
    {
        return toastTxt;
    }
    public GameObject GetToastGO()
    {
        return toastGO;
    }
    public Canvas GetToastCanvas()
    {
        return toastCanvas;
    }
    public IEnumerator TimeCountdownHide()
    {
        yield return new WaitForSeconds(showTime);
        toastGO.SetActive(false);
    }

    public IEnumerator TimeCountdownDespawn()
    {
        yield return new WaitForSeconds(lifespanTime);
        SpawnManager.DespawnToast(this);
    }

    public IEnumerator ICountText()
    {
        while (i <= 1000)
        {
            toastTxt.text = i.ToString();
            yield return new WaitForEndOfFrame();
            i++;
            if (i == 1000)
            {
                i = 1;
            }
        }
        StopAllCoroutines();
    }   
}
