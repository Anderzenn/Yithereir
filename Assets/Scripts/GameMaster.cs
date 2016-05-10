using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public int gNuggets;

    public Text gNuggetsText;
    public Text inputText;

    void Start()
    {
        if (PlayerPrefs.HasKey("GoldNuggets"))
        {
            if (Application.loadedLevel == 0)
            {
                PlayerPrefs.DeleteKey("GoldNuggets");
                gNuggets = 0;
            } else
            {
                gNuggets = PlayerPrefs.GetInt("GoldNuggets");
            }
        }
    }

    void Update()
    {
        gNuggetsText.text = ("Gold: " + gNuggets);
    }

}
