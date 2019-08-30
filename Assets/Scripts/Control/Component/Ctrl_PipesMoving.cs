using UnityEngine;
using System.Collections;

public class Ctrl_PipesMoving : MonoBehaviour
{
    public float movingSpeed = 1f;
    private Vector2 _VecOriginalPosition = Vector2.zero;
    private bool _IsStartGame = false;

    public void StartGame()
    {
        _IsStartGame = true;
    }

    public void StopGame()
    {
        _IsStartGame = false;
        ResetPipesPosition();
    }

    void Start()
    {
        _VecOriginalPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.x < -15f)
        {
            transform.position = _VecOriginalPosition;
        }
        transform.Translate(Vector2.left * Time.deltaTime * movingSpeed);
    }

    //管道复位
    private void ResetPipesPosition()
    {
        transform.position = _VecOriginalPosition;
    }
}
