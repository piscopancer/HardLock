using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelBackground : PanelBase
{
    protected override void Awake() {
        base.Awake();

        Themes.OnThemeChanged += (ThemeProfile profile) => {
            Document.rootVisualElement.Q<VisualElement>("background-image").style.backgroundImage = profile.Theme.BackgroundImage.texture;
        };
        Document.rootVisualElement.Q<VisualElement>("background-image").style.backgroundImage = Themes.CurrentTheme.Theme.BackgroundImage.texture;
    }
}
