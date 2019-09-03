using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

public class Ctrl_Gold : MonoBehaviour
{
    private Model_GameDataProxy _proxyObj = null;
    private bool _IsStartGame = false;

    public void StartGame()
    {
        _proxyObj = Facade.Instance.RetrieveProxy(Model_GameDataProxy.NAME) as Model_GameDataProxy;
        _IsStartGame = true;
    }

    public void StopGame()
    {
        _IsStartGame = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_IsStartGame)
        {
            if (collision.CompareTag("Player"))
            {
                _proxyObj.AddScores();
            }
        }
    }
}
