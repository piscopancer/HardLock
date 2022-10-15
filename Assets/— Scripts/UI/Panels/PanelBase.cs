using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using TriInspector;
using Cysharp.Threading.Tasks;

[RequireComponent(typeof(UIDocument))]
public abstract class PanelBase : MonoBehaviour
{
    [field: SerializeField, Required] public UIDocument Document { get; private set; }
    [SerializeField] bool isActiveOnStart = false;

    protected virtual void Awake()
    {
        Document.rootVisualElement.style.display = isActiveOnStart ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
