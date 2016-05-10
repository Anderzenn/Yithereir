using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDB : MonoBehaviour {
	private List<Item> db = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDB();
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < db.Count; i++)
            if (db[i].ID == id)
                return db[i];
        return null;
    }

    void ConstructItemDB()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            db.Add(new Item(
                (int)itemData[i]["id"],
                (string)itemData[i]["title"],
                (string)itemData[i]["type"],
                (int)itemData[i]["value"],
                (int)itemData[i]["stats"]["power"],
                (int)itemData[i]["stats"]["defence"],
                (int)itemData[i]["stats"]["vitality"],
                (string)itemData[i]["description"],
                (bool)itemData[i]["stackable"],
                (int)itemData[i]["rarity"],
                (string)itemData[i]["slug"],
                (string)itemData[i]["color"]                
                ));
        }
    }

}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public int Value { get; set; }
    public int Power { get; set; }
    public int Defence { get; set; }
    public int Vitality { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public string Color { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, string type, int value, int power, int defence, int vitality, string description, bool stackable, int rarity, string slug, string color)
    {
        this.ID = id;
        this.Title = title;
        this.Type = type;
        this.Value = value;
        this.Power = power;
        this.Defence = defence;
        this.Vitality = vitality;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
        this.Color = color;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

    public Item()
    {
        this.ID = -1;
    }
}
