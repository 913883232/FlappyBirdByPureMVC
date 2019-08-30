using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class Ctrl_RegisterModelAndViewCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        Facade.RegisterProxy(new Model_GameDataProxy());
        Facade.RegisterMediator(new View_GamePlayingMediator());
    }
}
