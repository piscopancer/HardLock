using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class CustomVisualElements
{
    
}

#region containers

public class ThemedContainerFirst : VisualElement
{
    public new class UxmlFactory : UxmlFactory<ThemedContainerFirst> { }

    ThemeData theme;

    public ThemedContainerFirst()
    {
        Themes.OnThemeChanged += (ThemeProfile profile) =>
        {
            style.backgroundColor = profile.Theme.ContainerFirst;
        };

        theme = Themes.CurrentTheme.Theme;
        style.backgroundColor = theme.ContainerFirst;
    }
}

public class ThemedContainerSecond : VisualElement
{
    public new class UxmlFactory : UxmlFactory<ThemedContainerSecond> { }

    ThemeData theme;

    public ThemedContainerSecond()
    {
        Themes.OnThemeChanged += (ThemeProfile profile) =>
        {
            style.backgroundColor = profile.Theme.ContainerSecond;
        };

        theme = Themes.CurrentTheme.Theme;
        style.backgroundColor = theme.ContainerSecond;
    }
}

#endregion

#region buttons

public class ThemedButtonZero : Button
{
    public new class UxmlFactory : UxmlFactory<ThemedButtonZero> { }

    ThemeData theme;

    public ThemedButtonZero()
    {
        Themes.OnThemeChanged += (ThemeProfile profile) =>
        {
            SetTheme(profile.Theme);
        };

        theme = Themes.CurrentTheme.Theme;
        SetTheme(theme);
    }

    void SetTheme(ThemeData theme)
    {
        style.backgroundColor = theme.ButtonZeroBackground;
        style.borderTopColor = theme.ButtonZeroBorder;
        style.borderRightColor = theme.ButtonZeroBorder;
        style.borderBottomColor = theme.ButtonZeroBorder;
        style.borderLeftColor = theme.ButtonZeroBorder;
    }
}

public class ThemedButtonFirst : Button
{
    public new class UxmlFactory : UxmlFactory<ThemedButtonFirst> { }

    ThemeData theme;

    public ThemedButtonFirst()
    {
        Themes.OnThemeChanged += (ThemeProfile profile) =>
        {
            SetTheme(profile.Theme);
        };

        theme = Themes.CurrentTheme.Theme;
        SetTheme(theme);
    }

    void SetTheme(ThemeData theme)
    {
        style.backgroundColor = theme.ButtonFirstBackground;
        style.borderTopColor = theme.ButtonFirstBorder;
        style.borderRightColor = theme.ButtonFirstBorder;
        style.borderBottomColor = theme.ButtonFirstBorder;
        style.borderLeftColor = theme.ButtonFirstBorder;
    }
}

public class ThemedButtonSecond : Button
{
    public new class UxmlFactory : UxmlFactory<ThemedButtonSecond> { }

    ThemeData theme;

    public ThemedButtonSecond()
    {
        Themes.OnThemeChanged += (ThemeProfile profile) =>
        {
            SetTheme(profile.Theme);
        };

        theme = Themes.CurrentTheme.Theme;
        SetTheme(theme);
    }

    void SetTheme(ThemeData theme)
    {
        style.backgroundColor = theme.ButtonSecondBackground;
        style.borderTopColor = theme.ButtonSecondBorder;
        style.borderRightColor = theme.ButtonSecondBorder;
        style.borderBottomColor = theme.ButtonSecondBorder;
        style.borderLeftColor = theme.ButtonSecondBorder;
    }
}

#endregion

#region labels

public abstract class ThemedLabel : Label
{
    protected Translation translation;
    protected ThemeData theme;

    public ThemedLabel() {
        Themes.OnThemeChanged += SetTheme;
        SetTheme(Themes.CurrentTheme);
    }
    public ThemedLabel(string text) : this(){    
        this.text = text;
    }
    public ThemedLabel(Translation translation) : this() {
        Language.OnLanguageChanged += (Languages language) => {
            SetTranslation(translation);
        };
        SetTranslation(translation);
    }

    public ThemedLabel SetTranslation(Translation translation)
    {
        this.translation = translation;
        text = translation.Text;
        return this;
    }

    protected virtual void SetTheme(ThemeProfile profile) {
        theme = profile.Theme;
    }

    public void DisableTheme() {
        Themes.OnThemeChanged -= SetTheme;
        theme = null;
        style.color = StyleKeyword.Null;
    }
}

public class ThemedLabelZero : ThemedLabel
{
    public new class UxmlFactory : UxmlFactory<ThemedLabelZero> { }

    public ThemedLabelZero() : base() { }
    public ThemedLabelZero(string text) : base(text) { }
    public ThemedLabelZero(Translation translation) : base(translation) { }

    protected override void SetTheme(ThemeProfile profile) {
        base.SetTheme(profile);
        style.color = theme.LabelZero;
    }
}

public class ThemedLabelFirst : ThemedLabel
{
    public new class UxmlFactory : UxmlFactory<ThemedLabelZero> { }

    public ThemedLabelFirst() : base() { }
    public ThemedLabelFirst(string text) : base(text) { }
    public ThemedLabelFirst(Translation translation) : base(translation) { }

    protected override void SetTheme(ThemeProfile profile)
    {
        base.SetTheme(profile);
        style.color = theme.LabelFirst;
    }
}

public class ThemedLabelSecond : ThemedLabel
{
    public new class UxmlFactory : UxmlFactory<ThemedLabelSecond> { }

    public ThemedLabelSecond() : base() { }
    public ThemedLabelSecond(string text) : base(text) { }
    public ThemedLabelSecond(Translation translation) : base(translation) { }

    protected override void SetTheme(ThemeProfile profile)
    {
        base.SetTheme(profile);
        style.color = theme.LabelSecond;
    }
}

#endregion

#region icons

public abstract class ThemedIcon : VisualElement
{
    protected ThemeData theme;

    protected ThemedIcon()
    {
        Themes.OnThemeChanged += (ThemeProfile profile) =>
        {
            SetTheme(profile.Theme);
        };
        SetTheme(Themes.CurrentTheme.Theme);
    }

    protected virtual void SetTheme(ThemeData theme)
    {
        this.theme = theme;
        style.backgroundColor = Color.clear;
    }
}

public class ThemedIconFirst : ThemedIcon
{
    public new class UxmlFactory : UxmlFactory<ThemedIconFirst> { }

    protected override void SetTheme(ThemeData theme)
    {
        base.SetTheme(theme);
        style.unityBackgroundImageTintColor = theme.IconFirst;
    }
}

public class ThemedIconSecond : ThemedIcon
{
    public new class UxmlFactory : UxmlFactory<ThemedIconSecond> { }

    protected override void SetTheme(ThemeData theme)
    {
        base.SetTheme(theme);
        style.unityBackgroundImageTintColor = theme.IconSecond;
    }
}

#endregion