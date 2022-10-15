using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using UnityEngine.UIElements;

public class LabelWithTranslation : Label
{
    public new class UxmlFactory : UxmlFactory<LabelWithTranslation, UxmlTraits> { }

    Translation translation;

    public LabelWithTranslation()
    {
        Debug.LogWarning("translation not assigned");
    }

    public LabelWithTranslation(Translation translation)
    {
        Language.OnLanguageChanged += (Languages language) =>
        {
            text = this.translation.Text;
        };
        SetTranslation(translation);
    }

    public LabelWithTranslation SetTranslation(Translation translation)
    {
        this.translation = translation;
        text = translation.Text;
        return this;
    }
}
