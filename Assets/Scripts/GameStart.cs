using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIFW;

public class GameStart : MonoBehaviour
{
    void Start()
    {
        UIManager.GetInstance().ShowUIForms("StartUIForm");
    }
}
