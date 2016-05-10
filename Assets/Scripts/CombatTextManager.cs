using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatTextManager : MonoBehaviour {

    private static CombatTextManager instance;

    public GameObject textPrefab;
    public RectTransform canvasTransform;

    public float speed;
    public Vector3 direction;
    public float fadeTime;

    public static CombatTextManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<CombatTextManager>();
            }
            return instance;
        }
    }

    public void CreateText(Vector3 position, string text, Color color)
    {
        GameObject sct = (GameObject)Instantiate(textPrefab, position, Quaternion.identity);

        sct.transform.SetParent(canvasTransform);
        sct.GetComponent<RectTransform>().localScale = new Vector3(0.07021222f, 0.07021222f, 0.07021222f);
        sct.GetComponent<CombatText>().Initialize(speed, direction, fadeTime);
        sct.GetComponent<Text>().text = text;
        sct.GetComponent<Text>().color = color;
    }

}
