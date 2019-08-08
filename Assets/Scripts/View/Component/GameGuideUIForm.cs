using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;
using PureMVC.Patterns;

public class GameGuideUIForm : BaseUIForm
{
    private void Awake()
    {
        //本窗体类型
        CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;

        //注册按钮事件
        RigisterButtonObjectEvent("BtnTap", p=>
            {
                OpenUIForm("GamePlayingUIForm");
                Facade.Instance.SendNotification("Reg_StartGameCommand");
            }
        );
    }
}
