using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    private Item item;
    private string data;
    private GameObject tooltip;

    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }

    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

	public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        data = "<color=" + item.Color + "><size=20>" + item.Title + "</size></color><size=12>\nType: " + item.Type + "\nDescription: \n" + item.Description + "\n\nPower: " + item.Power + "\nDefence: " + item.Defence + "</size>";
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }

}
