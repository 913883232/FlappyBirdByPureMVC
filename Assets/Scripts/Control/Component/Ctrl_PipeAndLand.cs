using UnityEngine;
using System.Collections;
using PureMVC.Patterns;

[RequireComponent(typeof(BoxCollider2D))]
public class Ctrl_PipeAndLand : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //通过PureMVC的通知机制，游戏结束
            Facade.Instance.SendNotification("Reg_EndGameCommand");
        }
    }
}
