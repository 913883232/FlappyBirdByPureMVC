using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using SUIFW;

public class Ctrl_RestartGameCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        //主角重新运行
        GameObject.FindGameObjectWithTag("Player").GetComponent<Ctrl_PlayerControl>().StartGame();
        //得到层级视图根节点
        GameObject goEnviroment = GameObject.Find("MainGameScene");
        //管道组开始运行
        UnityHelper.FindTheChildNode(goEnviroment, "GamePipes").GetComponent<Ctrl_PipesMoving>().StartGame();
        //获取时间脚本
        goEnviroment.GetComponent<Ctrl_GetTime>().StartGame();
        //“金币”道具启动
        for (int i = 0; i < 3; i++)
        {
            //金币道具开始运行
            UnityHelper.FindTheChildNode(goEnviroment, "pipe_" + i + "_trigger").GetComponent<Ctrl_Gold>().StartGame();
        }
    }
}
