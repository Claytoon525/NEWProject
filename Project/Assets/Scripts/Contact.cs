using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    public int damadge;
    public enum ItemType
    {
        Arrow,
        Lava
    }
    public ItemType item;
    [SerializeField] private ItemType _itemType;
    if(item == "Spike"")
    {
        damadge = 5;
    }
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player.health -= other.damadge;
        }
    }
}
