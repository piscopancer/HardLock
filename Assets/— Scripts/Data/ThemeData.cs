using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;

[CreateAssetMenu(menuName = "Data/Theme")]
public class ThemeData : ScriptableObject
{
    [InlineEditor] public Translation Name;
    public Color ShopColor;
    public Color BackgroundColor, Background2Color;
    public Color ArrowColor, PieceCenterColor, ActivePieceColor, NotActivePieceColor, PieceBackColor;
    public Color AccentColor;
    public Color ButtonColor, TextColor;
}
