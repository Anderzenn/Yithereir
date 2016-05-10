using UnityEngine;
using System.Collections;

public class InvUI : MonoBehaviour {

    public GameObject inventoryUI;

    private bool invOpen = false;

    void Start()
    {
        inventoryUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
        {
            invOpen = !invOpen;
        }

        if (invOpen)
        {
            inventoryUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!invOpen)
        {
            inventoryUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
