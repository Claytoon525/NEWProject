using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    public int damadge;
    public enum ItemType
    {
        Spike,
        Arrow,
        Lava
    }
    public ItemType item;
    [SerializeField] private ItemType _itemType;

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
            //player.health -= other.damadge;
        }
        //needs to be in collision function to work - Sam :)
        //also use switch case for comparing 

        //if(item == "Spike")
        //{
        //    damadge = 5;
        //}
        /*
        switch(ItemType){
            case ItemType.Spike:
                break;
            default: 
                break;
        }
        */
    }
}
