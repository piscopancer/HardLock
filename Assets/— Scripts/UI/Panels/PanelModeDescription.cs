using System;
using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelModeDescription : PanelBase
{
    protected override void Awake()
    {
        base.Awake();
    }
}

public class PanelModeDescriptionFile : PanelFileBase
{
    public new class UxmlFactory : UxmlFactory<PanelModeDescriptionFile> { }

    LabelWithTranslation labelDescription, labelModeDescription;

    public PanelModeDescriptionFile()
    {
        PanelMode.OnInfoClicked += (PuzzleMode mode) =>
        {
            Show();
            Setup(mode);
            Translate(this, new Vector2(0, 0), new Vector2(0, 200));
        };

        name = "panel";

        #region header

        var header = new VisualElement();
        header.name = "header";
        Add(header);

        labelDescription = new();
        labelDescription.name = "label-description";
        header.Add(labelDescription);

        #endregion

        #region main

        var main = new VisualElement();
        Add(main);

        labelModeDescription = new();
        labelModeDescription.name = "label-mode-description";
        main.Add(labelModeDescription);

        var buttonOK = new Button();
        buttonOK.AddClasses(buttonSmall, buttonFirst);
        main.Add(buttonOK);
        var labelButtonOK = new LabelWithTranslation(new Translation("Ok, and?", "ќк, ладно"));
        buttonOK.Add(labelButtonOK);

        #endregion
    }

    public void Setup(PuzzleMode mode)
    {
        labelDescription.text = mode.Name.Text;
        labelModeDescription.text = mode.Description.Text;
    }
}
