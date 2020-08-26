using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextProps : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public enum Scenes
    {
        Welcome,
        PvP,
        AIWelcome,
        GameAI,
        LevelsAI
    }

    public AI.Level Level;
    public Scenes SuitableScene;
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Text>().text = $">{gameObject.GetComponent<Text>().text}";
        gameObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Text>().text = gameObject.GetComponent<Text>().text.Remove(0, 1);
        gameObject.GetComponent<Text>().fontStyle = FontStyle.Normal;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        AI.Lvl = Level;

        SceneManager.LoadScene(SuitableScene.ToString());
        Punctation p = new Punctation();

        p.Reset();
    }
}
