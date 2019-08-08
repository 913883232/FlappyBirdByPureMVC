using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

[RequireComponent(typeof(Rigidbody2D))]
public class Ctrl_PlayerControl : MonoBehaviour
{
    public float upPower = 3f;
    private Rigidbody2D rig2D = null;
    private Vector2 _PlayerOriginalPos = Vector2.zero;
    private bool _IsGameStart = false;

    //游戏开始
    public void StartGame()
    {
        _IsGameStart = true;
        rig2D.isKinematic = false;
    }

    //游戏结束
    public void StopGame()
    {
        _IsGameStart = false;
        DisableRigidbody2D();
        this.gameObject.transform.position = _PlayerOriginalPos;
    }

    void Start()
    {
        _PlayerOriginalPos = this.gameObject.transform.position;
        rig2D = GetComponent<Rigidbody2D>();
        DisableRigidbody2D();
    }

    void Update()
    {
        if (_IsGameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rig2D.velocity = Vector2.up * upPower;
            }
        }
    }

    private void DisableRigidbody2D()
    {
        rig2D.isKinematic = true;
    }
}
