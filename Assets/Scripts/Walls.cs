using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Walls : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.transform.position.x < 0)
            PlayerPrefs.SetInt("P2", PlayerPrefs.GetInt("P2") + 1);
        else
            PlayerPrefs.SetInt("P1", PlayerPrefs.GetInt("P1") + 1);

        if (Punctation.Instance.Game)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
