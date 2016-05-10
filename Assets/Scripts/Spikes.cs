using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    private Player player;
    public int damage = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            player.Damage(damage);
            StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
        }
    }

}
