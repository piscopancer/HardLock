using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;

[CreateAssetMenu(menuName = "Data/Theme")]
public class ThemeData : ScriptableObject
{
    [field: SerializeField, Required, InlineEditor] public Translation Name { get; private set; }
    [Required] public Sprite BackgroundImage;
    public Color ShopColor;
    public Color ContainerFirst, ContainerSecond;
    public Color LabelZero, LabelFirst, LabelSecond;
    public Color IconFirst, IconSecond;
    public Color ButtonZeroBackground, ButtonZeroBorder;
    public Color ButtonFirstBackground, ButtonFirstBorder;
    public Color ButtonSecondBackground, ButtonSecondBorder;
}
