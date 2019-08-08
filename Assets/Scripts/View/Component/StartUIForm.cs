using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;

public class StartUIForm : BaseUIForm
{
    private void Awake()
    {
        //按钮注册
        RigisterButtonObjectEvent("ImgBegin", p =>
            OpenUIForm("GameGuideUIForm")
        );
    }

    private void Start()
    {
        //启动MVC 框架
        new ApplicationFacade();
    }

}
