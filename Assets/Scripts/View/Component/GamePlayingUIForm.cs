﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;

public class GamePlayingUIForm : BaseUIForm
{
    private void Awake()
    {
        CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;
    }
}
