using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

//定义角色的相关数据
//时间，分数，最高分数
public class Model_GameDataProxy:Proxy
{
    public new const string NAME = "Model_GameDataProxy";
    //游戏数据实体类
    private Model_GameData _GameData;

    public Model_GameDataProxy():base(NAME)
    {
        _GameData = new Model_GameData();
        //得到最高分数
        _GameData.HighestScores = PlayerPrefs.GetInt("GameHighestScores");
    }

    //增加游戏时间
    public void AddGameTime()
    {
        ++_GameData.GameTime;
        //数值发送到视图层
        SendNotification("Msg_DisplayGameInfo", _GameData);
    }

    public void AddScores()
    {
        ++_GameData.Scores;
        //更新最高分数
        GetHighestScores();
    }

    public int GetHighestScores()
    {
        if (_GameData.Scores > _GameData.HighestScores)
        {
            _GameData.HighestScores = _GameData.Scores;
        }
        return _GameData.HighestScores;
    }

    public void SaveHighestScores()
    {
        if (_GameData.HighestScores > PlayerPrefs.GetInt("GameHighestScores"))
        {
            PlayerPrefs.SetInt("GameHighestScores", _GameData.HighestScores);
        }
    }
}
