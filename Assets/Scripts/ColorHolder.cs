using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ColorLevel", order = 1)]
public class ColorHolder : ScriptableObject
{
    public List<Color> Colors = new List<Color>();
}
