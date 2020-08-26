using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    bool newVelocity;

    float speed = 3f;
    public static Level Lvl = Level.Begginer;
    public enum Level
    {
        Begginer,
        Medium,
        Hard
    }

    void Start() => newVelocity = true;

    void Update()
    {
        if (Punctation.Instance.Game)
                switch (Lvl)
                {
                    default:
                        case Level.Begginer:
                            doBegginerAct();
                            break;
                        case Level.Medium:
                            doMediumAct();
                            break;
                        case Level.Hard:
                            doHardAct();
                            break;
                }
    }

    private void doHardAct()
    {
        speed = 4f;
        if (newVelocity)
        {
            Ball.Instance.SetNewSpeed(4.5f);
            newVelocity = false;
        }
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance > 20)
        {
            Vector3 myPos = gameObject.transform.position + new Vector3(0, gameObject.GetComponent<SpriteRenderer>().sprite.rect.height / 2, 0);
            if (gameObject.transform.position.y > Ball.Instance.gameObject.transform.position.y)
                speed = Mathf.Abs(speed) * -1;
            else
                speed = Mathf.Abs(speed);
        }
        gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider is CircleCollider2D) return;
        speed = -speed;
    }

    private void doMediumAct()
    {
        if (newVelocity)
        {
            Ball.Instance.SetNewSpeed(3f);
            newVelocity = false;
        }
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance > 50)
        {
            Vector3 myPos = gameObject.transform.position + new Vector3(0, gameObject.GetComponent<SpriteRenderer>().sprite.rect.height / 2, 0);
            if (gameObject.transform.position.y > Ball.Instance.gameObject.transform.position.y)
                speed = Mathf.Abs(speed) * -1;
            else
                speed = Mathf.Abs(speed);
        }
        gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    private void doBegginerAct()
    {
        if (newVelocity)
        {
            Ball.Instance.SetNewSpeed(3f);
            newVelocity = false;
        }
        if (Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, transform.localScale.y + gameObject.GetComponent<BoxCollider2D>().size.y / 13, 0)).y >= Screen.height
            | Camera.main.WorldToScreenPoint(transform.position - new Vector3(0, transform.localScale.y + gameObject.GetComponent<BoxCollider2D>().size.y / 13, 0)).y <= 0)
        {
            speed *= -1;
        }
        gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("P1", 0);
        PlayerPrefs.SetInt("P2", 0);
    }
}
