using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    
    public int damadge = 10;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnCollisionEnter()
    {
         player.takeDamadge(damadge);
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        player.takeDamadge(damadge);
            //player.health -= other.damadge;
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
