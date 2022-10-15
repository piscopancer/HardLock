using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;

[CreateAssetMenu(menuName = "Data/Theme")]
public class ThemeData : ScriptableObject
{
    [Required, InlineEditor] public Translation Name;
    public Color ShopColor, ButtonColor;
    
}
