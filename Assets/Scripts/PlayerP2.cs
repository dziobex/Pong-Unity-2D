using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerP2 : MonoBehaviour
{
    void Update()
    {
        if (Punctation.Instance.Game)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.transform.position += new Vector3(0, 3 * Time.deltaTime, 0);
                if (Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, transform.localScale.y + gameObject.GetComponent<BoxCollider2D>().size.y / 13, 0)).y >= Screen.height)
                    gameObject.transform.position -= new Vector3(0, 3 * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.position += new Vector3(0, -3 * Time.deltaTime, 0);
                if (Camera.main.WorldToScreenPoint(transform.position - new Vector3(0, transform.localScale.y + gameObject.GetComponent<BoxCollider2D>().size.y / 13, 0)).y <= 0)
                    gameObject.transform.position -= new Vector3(0, -3 * Time.deltaTime, 0);
            }
        }
    }
}
