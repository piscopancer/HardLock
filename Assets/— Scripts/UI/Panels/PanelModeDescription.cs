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

    ThemedContainerSecond body;
    ThemedLabelSecond labelHeader;
    ThemedLabelFirst labelModeDescription;

    public PanelModeDescriptionFile(){
        PanelModeFile.OnInfoClicked += (PuzzleMode mode) =>{
            Show();
            Setup(mode);
            Translate(body, new Vector2(0, 0), new Vector2(0, 200));
        };

        body = new ThemedContainerSecond();
        Add(body);
        body.name = "body";

        #region header

        var header = new ThemedContainerFirst();
        body.Add(header);
        header.name = "header";

        labelHeader = new(new Translation("name here", "название тут"));
        header.Add(labelHeader);
        labelHeader.name = "label-header";

        #endregion

        #region main

        var main = new VisualElement();
        body.Add(main);
        main.name = "main";

        labelModeDescription = new(new Translation("description here", "описание тут"));
        main.Add(labelModeDescription);
        labelModeDescription.name = "label-mode-description";

        var buttonOK = new ThemedButtonSecond();
        main.Add(buttonOK);
        buttonOK.name = "button-ok";
        buttonOK.RegisterCallback((ClickEvent click) =>
        {
            Hide();
        });
        var labelButtonOK = new ThemedLabelSecond(new Translation("Ok, and?", "Ок, ладно"));
        buttonOK.Add(labelButtonOK);

        #endregion
    }

    public void Setup(PuzzleMode mode)
    {
        labelHeader.text = mode.Name.Text;
        labelModeDescription.text = mode.Description.Text;
    }
}
