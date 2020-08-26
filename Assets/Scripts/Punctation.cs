using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punctation : MonoBehaviour
{
    [SerializeField] public int RightSide;
    [SerializeField] public int LeftSide;

    public static Punctation Instance;
    public bool Game = true;
    public string WhoWon;
    public GameObject GOToAnimate;

    void Awake()
    {
        Instance = this;
        GOToAnimate.SetActive(false);
    }

    void Start()
    {
        RightSide = PlayerPrefs.GetInt("P1");
        LeftSide = PlayerPrefs.GetInt("P2");
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("P1", 0);
        PlayerPrefs.SetInt("P2", 0);
        Game = true;
        WhoWon = "";
    }

    void Update()
    {
        if (gameObject.GetComponent<Text>() != null) gameObject.GetComponent<Text>().text = $"{PlayerPrefs.GetInt("P1")}   {PlayerPrefs.GetInt("P2")}";
        
        if (PlayerPrefs.GetInt("P1") == 11)
        {
            Game = false;
            WhoWon = "P1";
            activateGO();
        }
        else if (PlayerPrefs.GetInt("P2") == 11)
        {
            Game = false;
            WhoWon = "P2";
            activateGO();
        }
    }

    void activateGO()
    {
        GOToAnimate.SetActive(true);
        GOToAnimate.transform.Find("Text").GetComponent<Text>().text = $"{WhoWon} won, congrats.";
        GOToAnimate.GetComponent<Animator>().Play("WindowGO");
    }
}
