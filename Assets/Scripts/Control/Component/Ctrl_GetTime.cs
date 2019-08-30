using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class Ctrl_GetTime : MonoBehaviour
{
    //模型代理
    public Model_GameDataProxy dataProxy = null;
    //游戏是否开始
    private bool isStartGame = false;

    public void StartGame()
    {
        dataProxy = Facade.Instance.RetrieveProxy(Model_GameDataProxy.NAME) as Model_GameDataProxy;
        isStartGame = true;
    }

    public void StopGame()
    {
        isStartGame = false;
    }

    void Start()
    {
        //启动协程，每隔一秒钟，往PureMVC模型层发送一条消息
        StartCoroutine("GetTime");
    }

    private IEnumerator GetTime()
    {
        yield return new WaitForEndOfFrame();
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (dataProxy != null && isStartGame)
            {
                dataProxy.AddGameTime();
            }
        }
    }
}
