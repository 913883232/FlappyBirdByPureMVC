using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using SUIFW;

public class ApplicationFacade : Facade
{
    public ApplicationFacade()
    {
        //注册核心命令
        RegisterCommand(ProjectConsts.Reg_StartGameCommand, typeof(Ctrl_StartGameCommand));
        RegisterCommand(ProjectConsts.Reg_EndGameCommand, typeof(Ctrl_EndGameCommand));
        //添加游戏对象脚本
        AddGameObjectScript();
    }

    private void AddGameObjectScript()
    {
        //得到层级视图的根对象
        GameObject goEnviromentRoot = GameObject.Find("MainGameScene");
        goEnviromentRoot.AddComponent<Ctrl_GetTime>();

        //添加主角控制脚本
        GameObject.FindGameObjectWithTag("Player").AddComponent<Ctrl_PlayerControl>();

        UnityHelper.AddChildNodeCompnent<Ctrl_LandMoving>(goEnviromentRoot, "GameLanding");

        UnityHelper.AddChildNodeCompnent<Ctrl_PipesMoving>(goEnviromentRoot, "GamePipes");

        for (int i = 0; i < 3; i++)
        {
            UnityHelper.AddChildNodeCompnent<Ctrl_PipeAndLand>(goEnviromentRoot, "pipe_" + i + "_down");
            UnityHelper.AddChildNodeCompnent<Ctrl_PipeAndLand>(goEnviromentRoot, "pipe_" + i + "_up");
            UnityHelper.AddChildNodeCompnent<Ctrl_PipeAndLand>(goEnviromentRoot, "land_" + i);
        }
        for (int i = 0; i < 3; i++)
        {
            UnityHelper.AddChildNodeCompnent<Ctrl_Gold>(goEnviromentRoot, "pipe_" + i + "_trigger");
        }
    }
}
