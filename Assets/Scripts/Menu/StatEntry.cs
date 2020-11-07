using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatEntry : MonoBehaviour
{
    public Text StatNameText;
    public Text StatValueText;

    public void SetData(string name, string value)
    {
        StatNameText.text = name;
        StatValueText.text = value;
    }
}
