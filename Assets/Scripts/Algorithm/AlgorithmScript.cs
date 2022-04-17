using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlgorithmScript : MonoBehaviour
{
    [SerializeField]
    InputField InputStringS;

    [SerializeField]
    InputField InputStringK;

    [SerializeField]
    TextMeshProUGUI resultTxt;

    string s;
    List<string> listCharNum;
    List<string> listCombineNum;
    bool isNumber = false;

    private void Start()
    {
        InputStringS.characterLimit = 1000000;
    }

    private void Update()
    {
        InputStringK.characterLimit = InputStringS.text.Length;
    }

    public void FilterNumber()
    {
        s = InputStringS.text;
        bool isNum = int.TryParse(s, out _);
        if (isNum)
        {
            resultTxt.color = Color.green;
            resultTxt.text = "Return True: s = " + s;
        }
        else
        {
            resultTxt.color = Color.red;
            resultTxt.text = "Return False: s = " + s;
        }
        isNumber = isNum;
    }

    public void FindBiggestNum(int k)
    {
        FilterNumber();
        if (isNumber)
        {
            int countInputString = s.Length;
            if (countInputString > 2)
            {
                int outputLenght = countInputString - k;
                if (outputLenght > 0)
                {
                    resultTxt.color = Color.red;
                    resultTxt.text = "Unfinished function";
                }
                else
                {
                    resultTxt.color = Color.yellow;
                    resultTxt.text = "string k value input must always smaller than string s value";
                    return;
                }
            }
            else
            {
                resultTxt.color = Color.yellow;
                resultTxt.text = "Input must have 2 or more digits";
                return;
            }
        }
        else
        {
            resultTxt.color = Color.red;
            resultTxt.text = "the input must be a string of numbers";
            return;
        }
    }
    public void FilterNumberBtn()
    {
        s = InputStringS.text;
        if (s.Length < 9)
        {
            FilterNumber();
        }
        else
        {
            resultTxt.color = Color.yellow;
            resultTxt.text = "Input can only from 1 to 8";
        }
    }
}
