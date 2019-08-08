using UnityEngine;
using System.Collections;

public class Ctrl_LandMoving : MonoBehaviour
{
    public float movingSpeed = 1f;
    private Vector2 _VecOriginalPosition = Vector2.zero;

    void Start()
    {
        _VecOriginalPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.x < -4f)
        {
            transform.position = _VecOriginalPosition;
        }
        transform.Translate(Vector2.left * Time.deltaTime * movingSpeed);
    }
}
