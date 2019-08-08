using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_StartGameCommand : MacroCommand
{
    protected override void InitializeMacroCommand()
    {
        //注册模型与视图Command
        AddSubCommand(typeof(Ctrl_RegisterModelAndViewCommand));
        //注册重新开始Command
        AddSubCommand(typeof(Ctrl_RestartGameCommand));
    }
}
