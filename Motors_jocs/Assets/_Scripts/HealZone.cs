using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHealth;

    public float timeBetweenHeal = 1.5f;
    public int healAmmount = 5;
    public int maxHealTimes = 5;
    public int HealTimes = 0;
    float timer;
    bool playerInRange = false;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("FPSController");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

	void OnTriggerEnter (Collider other)
    {
        Debug.Log("object entered the trigger");
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("object staying in the trigger");
        playerInRange = true;
        
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("object out the trigger");
        playerInRange = false;

    }

    void Update ()
    {
        timer += Time.deltaTime;

        if(timer > timeBetweenHeal && HealTimes < maxHealTimes && playerInRange)
        {
            Debug.Log("Heal()");
            Heal();
        }
    }

    public void Heal()
    {
        //reset the timer
        timer = 0f;

        //if the player have not the full life
        if(playerHealth.currentHealth < 100)
        {
            //heal the player
            playerHealth.HealPlayer(healAmmount);

            HealTimes++;
        }
    }
}
