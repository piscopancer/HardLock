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
        PanelModeFile.OnInfoClicked += async(PuzzleMode mode) =>{
            Show();
            Setup(mode);
            body.Fade(FadeMode.Show);
            body.Translate(new Vector2(0, 0), new Vector2(0, 400));
        };

        style.backgroundColor = new Color(0, 0, 0, 0.8f);

        body = new ThemedContainerSecond();
        Add(body);
        body.name = "body";

        #region header

        var header = new ThemedContainerFirst();
        body.Add(header);
        header.name = "header";

        labelHeader = new(new Translation("name here", "???????? ???"));
        header.Add(labelHeader);
        labelHeader.name = "label-header";

        #endregion

        #region main

        var main = new VisualElement();
        body.Add(main);
        main.name = "main";

        labelModeDescription = new(new Translation("description here", "???????? ???"));
        main.Add(labelModeDescription);
        labelModeDescription.name = "label-mode-description";

        var buttonOK = new ThemedButtonSecond();
        main.Add(buttonOK);
        buttonOK.name = "button-ok";
        buttonOK.RegisterCallback(async (ClickEvent click) =>
        {
            await body.Fade(FadeMode.Hide);
            Hide();
        });
        var labelButtonOK = new ThemedLabelSecond(new Translation("Ok, and?", "??, ?????"));
        buttonOK.Add(labelButtonOK);

        #endregion
    }

    public void Setup(PuzzleMode mode)
    {
        labelHeader.text = mode.Name.Text;
        labelModeDescription.text = mode.Description.Text;
    }
}
