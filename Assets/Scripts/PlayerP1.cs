using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerP1 : MonoBehaviour
{
    bool newVelocity = true;
    void Start() => newVelocity = true;
    void Update()
    {
        if (newVelocity)
        {
            Ball.Instance.SetNewSpeed(3f);
            newVelocity = false;
        }
        if (Punctation.Instance.Game)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.position += new Vector3(0, 3 * Time.deltaTime, 0);
                if (Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, transform.localScale.y + gameObject.GetComponent<BoxCollider2D>().size.y / 13, 0)).y >= Screen.height)
                    gameObject.transform.position -= new Vector3(0, 3 * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position += new Vector3(0, -3 * Time.deltaTime, 0);
                if (Camera.main.WorldToScreenPoint(transform.position - new Vector3(0, transform.localScale.y + gameObject.GetComponent<BoxCollider2D>().size.y / 13, 0)).y <= 0)
                    gameObject.transform.position -= new Vector3(0, -3 * Time.deltaTime, 0);
            }
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("P1", 0);
        PlayerPrefs.SetInt("P2", 0);
    }
}
