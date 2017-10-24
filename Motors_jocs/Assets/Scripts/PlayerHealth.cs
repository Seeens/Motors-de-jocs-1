using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 50;
    public int currentHealth;
    public Slider healthSlider;

    void Awake ()
    {
        //set the initial health of the player
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage (int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;

    }

    public void HealPlayer (int amount)
    {
        currentHealth += amount;
        healthSlider.value = currentHealth;
    }
}
