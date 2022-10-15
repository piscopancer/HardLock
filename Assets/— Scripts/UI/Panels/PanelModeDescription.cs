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

    VisualElement body;
    LabelWithTranslation labelHeader, labelModeDescription;

    public PanelModeDescriptionFile()
    {
        PanelModeFile.OnInfoClicked += (PuzzleMode mode) =>
        {
            Show();
            Setup(mode);
            Translate(body, new Vector2(0, 0), new Vector2(0, 200));
        };

        body = new VisualElement();
        Add(body);
        body.name = "body";
        body.AddClasses(backgroundFirst);

        #region header

        var header = new VisualElement();
        body.Add(header);
        header.name = "header";
        header.AddClasses(backgroundSecond);

        labelHeader = new();
        header.Add(labelHeader);
        labelHeader.name = "label-header";
        labelHeader.text = "mode name";
        labelHeader.AddClasses(textSecond);

        #endregion

        #region main

        var main = new VisualElement();
        body.Add(main);
        main.name = "main";

        labelModeDescription = new();
        main.Add(labelModeDescription);
        labelModeDescription.name = "label-mode-description";
        labelModeDescription.text = "mode description text here";
        labelModeDescription.AddClasses(textFirst);

        var buttonOK = new Button();
        main.Add(buttonOK);
        buttonOK.name = "button-ok";
        buttonOK.AddClasses(buttonSmall, buttonFirst);
        buttonOK.RegisterCallback((ClickEvent click) =>
        {
            Hide();
        });
        var labelButtonOK = new LabelWithTranslation(new Translation("Ok, and?", "ќк, ладно"));
        buttonOK.Add(labelButtonOK);
        buttonOK.RegisterCallback((ClickEvent click) =>
        {
            Hide();
        });
        labelButtonOK.AddClasses(textSecond);

        #endregion
    }

    public void Setup(PuzzleMode mode)
    {
        labelHeader.text = mode.Name.Text;
        labelModeDescription.text = mode.Description.Text;
    }
}
