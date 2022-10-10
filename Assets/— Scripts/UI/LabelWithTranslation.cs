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
        Language.OnLanguageChanged += (Languages language) =>
        {
            text = translation.Text;
        };
        text = "";
    }

    public void SetTranslation(Translation translation)
    {
        this.translation = translation;
        text = translation.Text;
    }
}
