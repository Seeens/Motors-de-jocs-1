using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectWrapper : MonoBehaviour {

    // Duration of the effect in seconds (float)
    public float burnTimer = 3f;
    public float slowTimer = 3f;
    public float frozenTimer = 3f;
    public float stunTimer = 3f;    
    public float minorMetalTimer = 3f;    
    public float majorMetalTimer = 3f;
    public float blindTimer = 3f; 
    public float speedBoostTimer = 3f;

    // Boolean to keep track which effects are on
    private bool burning = false;
    private bool slowed = false;
    private bool frozen = false;
    private bool stunned = false;
    private bool minorMetalProtection = false;
    private bool majorMetalProtection = false;
    private bool speedBoost = false;
    private bool blinded = false;

    // Delta timers to keep track of the elapsed time 
    private float burnDelta = 0f;
    private float slowDelta = 0f;
    private float frozenDelta = 0f;
    private float stunDelta = 0f;
    private float minorMetalDelta = 0f;
    private float majorMetalDelta = 0f;
    private float blindDelta = 0f;
    private float speedBoostDelta = 0f;

    // Extra variables for some effects
    public int burnTickCounter = 0;
    public int burnTickMax = 3;

    // Burn effect members
    public void StartBurn() {
        burning = true;
    }

    public void StopBurn() {
        burning = false;
        burnDelta = 0f;
        burnTickCounter = 0;
    }

    public void processBurn() {
        burnDelta = burnDelta + Time.deltaTime;
        if (burnTickCounter < burnTickMax && burnDelta >= 1f) {
            burnTickCounter = burnTickCounter + 1;
            burnDelta = 0f;
            // Apply burn damage code here
        }
        else if (burnTickCounter == burnTickMax) StopBurn();
    }

    // Slow effect members
    public void StartSlow() {
        slowed = true;
        // Slow flag code here
    }

    public void StopSlow() {
        slowed = false;
        slowDelta = 0f;
        // Slow flag code here
    }

    public void processSlow() {
        slowDelta = slowDelta + Time.deltaTime;
        if (slowDelta >= slowTimer) StopSlow();
    }

    // Frozen effect members
    public void StartFrozen() {
        frozen = true;
        // Frozen flag code here
    }

    public void StopFrozen() {
        frozen = false;
        frozenDelta = 0F;
        // Frozen flag code here
    }

    public void processFrozen() {
        frozenDelta = frozenDelta + Time.deltaTime;
        if (frozenDelta >= frozenTimer) StopFrozen();
    }

    // Stun effect members
    public void StartStun() {
        frozen = true;
        // Stun flag code here
    }

    public void StopStun() {
        frozen = false;
        frozenDelta = 0F;
        // Stun flag code here
    }

    public void processStun() {
        stunDelta = stunDelta + Time.deltaTime;
        if (stunDelta >= stunTimer) StopStun();
    }

    // Minor Metal effect members
    public void StartMinorMetal() {
        minorMetalProtection = true;
        // Minor Metal protection flag here
    }

    public void StopMinorMetal() {
        minorMetalProtection = false;
        minorMetalDelta = 0F;
        // Minor Metal protection flag here
    }

    public void processMinorMetal() {
        minorMetalDelta = minorMetalDelta + Time.deltaTime;
        if (minorMetalDelta >= minorMetalTimer) StopMinorMetal();
    }

    // Minor Metal effect members
    public void StartMajorMetal() {
        majorMetalProtection = true;
        // Major Metal protection flag here
    }

    public void StopMajorMetal() {
        majorMetalProtection = false;
        majorMetalDelta = 0F;
        // Major Metal protection flag here
    }

    public void processMajorMetal() {
        majorMetalDelta = majorMetalDelta + Time.deltaTime;
        if (majorMetalDelta >= majorMetalTimer) StopMajorMetal();
    }

    // Minor Metal effect members
    public void StartBlind() {
       blinded = true;
        // Blind flag here
    }

    public void StopBlind() {
        blinded = false;
        blindDelta = 0F;
        // Blind flag code here
    }

    public void processBlind() {
        blindDelta = blindDelta + Time.deltaTime;
        if (blindDelta >= blindTimer) StopBlind();
    }

    // Minor Metal effect members
    public void StartSpeedBoost() {
        speedBoost = true;
        // Blind flag here
    }

    public void StopSpeedBoost() {
        speedBoost = false;
        speedBoostDelta = 0F;
        // Speed Boost flag code here
    }

    public void processSpeedBoost() {
        speedBoostDelta = speedBoostDelta + Time.deltaTime;
        if (speedBoostDelta >= speedBoostTimer) StopSpeedBoost();
    }

    // Updater for the timers
    void Update () {
        if (burning) processBurn();
        if (slowed) processSlow();
        if (frozen) processFrozen();
        if (stunned) processStun();
        if (minorMetalProtection) processMinorMetal();
        if (majorMetalProtection) processMajorMetal();
        if (blinded) processBlind();
        if (speedBoost) processSpeedBoost();
    }
}
