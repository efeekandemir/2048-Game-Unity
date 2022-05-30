using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Number : MonoBehaviour
{
    public TextMeshPro text;
    public ColorHolder ColorHolder;
    public Color firstLevel;
    public int level;

    private int currentValue;
    private int CurrentValue
    {
        get => currentValue;
        set
        {
            var tempLevel = (int)Mathf.Pow(2, level);
            text.text = tempLevel.ToString();
            currentValue = tempLevel;
            GetComponent<SpriteRenderer>().color = ColorHolder.Colors[level - 1];
            text.color = level > 2 ? Color.white : firstLevel;
            currentValue = value;
        }
    }

    [ContextMenu("SetNumber")]
    public void SetNumber()
    {
        CurrentValue = level;
    }
}
