using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using SUIFW;

public class Ctrl_EndGameCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        //主角停止运行
        GameObject.FindGameObjectWithTag("Player").GetComponent<Ctrl_PlayerControl>().StopGame();

        GameObject goEnviromentRoot = GameObject.Find("MainGameScene");
        //管道组复位
        UnityHelper.FindTheChildNode(goEnviromentRoot, "GamePipes").GetComponent<Ctrl_PipesMoving>().StopGame();
    }
}
