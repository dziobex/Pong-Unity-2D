using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance;

    void Awake()
    {
        Instance = this;
    }

    public void SetNewSpeed(float speed)
    {
        if (Punctation.Instance.Game)
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, speed);
    }
}