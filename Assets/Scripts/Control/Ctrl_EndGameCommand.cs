using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using SUIFW;

public class Ctrl_EndGameCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        StopScriptRunning();
        CloseCurrentUIForm();
        //保存当前最高分数
        Model_GameDataProxy gameData = Facade.RetrieveProxy(Model_GameDataProxy.NAME) as Model_GameDataProxy;
        gameData.SaveHighestScores();
    }

    private void StopScriptRunning()
    {
        //主角停止运行
        GameObject.FindGameObjectWithTag("Player").GetComponent<Ctrl_PlayerControl>().StopGame();

        GameObject goEnviromentRoot = GameObject.Find("MainGameScene");
        //管道组复位
        UnityHelper.FindTheChildNode(goEnviromentRoot, "GamePipes").GetComponent<Ctrl_PipesMoving>().StopGame();

        goEnviromentRoot.GetComponent<Ctrl_GetTime>().StopGame();
        //“金币”道具停止
        for (int i = 0; i < 3; i++)
        {
            //金币道具开始运行
            UnityHelper.FindTheChildNode(goEnviromentRoot, "pipe_" + i + "_trigger").GetComponent<Ctrl_Gold>().StopGame();
        }
    }

    private void CloseCurrentUIForm()
    {
        UIManager.GetInstance().CloseUIForms("GamePlayingUIForm");
    }
}
