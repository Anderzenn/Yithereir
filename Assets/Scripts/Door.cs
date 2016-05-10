using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public int LevelToLoad;

    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.inputText.text = ("Press [E] to Enter");
            if (Input.GetKeyDown(KeyCode.E))
            {
                SaveScore();
                SceneManager.LoadScene(LevelToLoad);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SaveScore();
                SceneManager.LoadScene(LevelToLoad);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.inputText.text = ("");
        }
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("GoldNuggets", gm.gNuggets);
    }

}
