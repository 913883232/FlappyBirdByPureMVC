using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using UnityEngine.UI;
using SUIFW;
using PureMVC.Interfaces;

public class View_GamePlayingMediator : Mediator
{
    public new const string NAME = "View_GamePlayingMediator";
    //控件定义
    private Text _TxtGameTime = null;
    private Text _TxtShowGameTime = null;

    private Text _TxtGameScore = null;
    private Text _TxtShowGameScore = null;

    private Text _TxtGameHighestScore = null;
    private Text _TxtShowGameHighestScore = null;

    public View_GamePlayingMediator() : base(NAME)
    {
        //得到层级视图根节点
        GameObject goRootCanvas = GameObject.Find("Canvas(Clone)");
        _TxtGameTime = UnityHelper.GetTheChildNodeComponetScripts<Text>(goRootCanvas, "TxtTime");
        _TxtGameScore = UnityHelper.GetTheChildNodeComponetScripts<Text>(goRootCanvas, "TxtScore");
        _TxtGameHighestScore = UnityHelper.GetTheChildNodeComponetScripts<Text>(goRootCanvas, "TxtHighScore");
        _TxtGameTime.text = "时间:";
        _TxtGameScore.text = "分数:";
        _TxtGameHighestScore.text = "最高:";

        _TxtShowGameTime = UnityHelper.GetTheChildNodeComponetScripts<Text>(goRootCanvas, "TxtTimeShow");
        _TxtShowGameScore = UnityHelper.GetTheChildNodeComponetScripts<Text>(goRootCanvas, "TxtScoreShow");
        _TxtShowGameHighestScore = UnityHelper.GetTheChildNodeComponetScripts<Text>(goRootCanvas, "TxtHighScoreShow");
    }

    /// <summary>
    /// 允许可以接收的消息列表
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests()
    {
        IList<string> listResult = new List<string>();
        listResult.Add("Msg_DisplayGameInfo");
        return listResult;
    }

    /// <summary>
    /// 处理接收的消息列表
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        Model_GameData gameData = null;

        switch (notification.Name)
        {
            case "Msg_DisplayGameInfo":
                gameData = notification.Body as Model_GameData;
                if (gameData != null)
                {
                    if (_TxtShowGameTime && _TxtShowGameScore && _TxtShowGameHighestScore)
                    {
                        _TxtShowGameTime.text = gameData.GameTime.ToString();
                        _TxtShowGameScore.text = gameData.Scores.ToString();
                        _TxtShowGameHighestScore.text = gameData.HighestScores.ToString();
                    }
                }
                break;
            default:
                break;
        }
    }
}
