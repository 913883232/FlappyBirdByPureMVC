using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class Ctrl_RestartGameCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        //主角重新运行
        GameObject.FindGameObjectWithTag("Player").GetComponent<Ctrl_PlayerControl>().StartGame();
    }
}
