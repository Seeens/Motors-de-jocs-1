using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spell.EffectWrapper
{
    public class EffectWrapper : MonoBehaviour
    {
        // Duration of the effect in seconds (float)
        [HideInInspector] public float slowTimer = 3f;
        [HideInInspector] public float frozenTimer = 3f;
        [HideInInspector] public float stunTimer = 3f;
        [HideInInspector] public float minorMetalTimer = 3f;
        [HideInInspector] public float majorMetalTimer = 3f;
        [HideInInspector] public float blindTimer = 3f;
        [HideInInspector] public float dashTimer = 0.5f;
        [HideInInspector] public float speedBoostTimer = 3f;

        // Boolean to keep track which effects are on
        [HideInInspector] public bool burning = false;
        [HideInInspector] public bool slowed = false;
        [HideInInspector] public bool frozen = false;
        [HideInInspector] public bool stunned = false;
        [HideInInspector] public bool minorMetalProtection = false;
        [HideInInspector] public bool majorMetalProtection = false;
        [HideInInspector] public bool speedBoost = false;
        [HideInInspector] public bool blinded = false;
        [HideInInspector] public bool dashing = false;

        // Delta timers to keep track of the elapsed time
        [HideInInspector] public float burnDelta;
        [HideInInspector] public float slowDelta = 0f;
        [HideInInspector] public float frozenDelta = 0f;
        [HideInInspector] public float stunDelta = 0f;
        [HideInInspector] public float minorMetalDelta = 0f;
        [HideInInspector] public float majorMetalDelta = 0f;
        [HideInInspector] public float blindDelta = 0f;
        //[HideInInspector] private float dashDelta = 0f;
        [HideInInspector] public float speedBoostDelta = 0f;

        // Extra variables for some effects
        [HideInInspector] public int dashDistance = 10;
        [HideInInspector] public float dashSpeed = 50f;
        [HideInInspector] public float distanceDelta;
        [HideInInspector] public Vector3 positionDelta;
        [HideInInspector] public int burnTickCounter;
        [HideInInspector] public int burnTickMax;
        [HideInInspector] public float burnTickDamage;

        private Player_State _player;

        public void StartBurn()
        {
            burnTickCounter = 0;
            burning = true;
        }

        private void StopBurn()
        {
            burning = false;
            burnDelta = 0f;
            burnTickCounter = 0;
        }

        private void ProcessBurn()
        {
            burnDelta = burnDelta + Time.deltaTime;
            if (burnTickCounter < burnTickMax && burnDelta >= 1f)
            {
                burnTickCounter = burnTickCounter + 1;
                burnDelta = 0f;
                _player.YieldDamage(burnTickDamage);
            }
            else if (burnTickCounter == burnTickMax) StopBurn();
        }

        // Slow effect members
        public void StartSlow()
        {
            slowed = true;
            // Slow flag code here
        }

        private void StopSlow()
        {
            slowed = false;
            slowDelta = 0f;
            // Slow flag code here
        }

        private void ProcessSlow()
        {
            slowDelta = slowDelta + Time.deltaTime;
            if (slowDelta >= slowTimer) StopSlow();
        }

        // Frozen effect members
        public void StartFrozen()
        {
            frozen = true;
            // Frozen flag code here
        }

        private void StopFrozen()
        {
            frozen = false;
            frozenDelta = 0f;
            // Frozen flag code here
        }

        private void ProcessFrozen()
        {
            frozenDelta = frozenDelta + Time.deltaTime;
            if (frozenDelta >= frozenTimer) StopFrozen();
        }

        // Stun effect members
        public void StartStun()
        {
            frozen = true;
            // Stun flag code here
        }

        private void StopStun()
        {
            frozen = false;
            frozenDelta = 0f;
            // Stun flag code here
        }

        private void ProcessStun()
        {
            stunDelta = stunDelta + Time.deltaTime;
            if (stunDelta >= stunTimer) StopStun();
        }

        // Minor Metal effect members
        public void StartMinorMetal()
        {
            minorMetalProtection = true;
            // Minor Metal protection flag here
        }

        private void StopMinorMetal()
        {
            minorMetalProtection = false;
            minorMetalDelta = 0f;
            // Minor Metal protection flag here
        }

        private void ProcessMinorMetal()
        {
            minorMetalDelta = minorMetalDelta + Time.deltaTime;
            if (minorMetalDelta >= minorMetalTimer) StopMinorMetal();
        }

        // Major Metal effect members
        public void StartMajorMetal()
        {
            majorMetalProtection = true;
            // Major Metal protection flag here
        }

        private void StopMajorMetal()
        {
            majorMetalProtection = false;
            majorMetalDelta = 0f;
            // Major Metal protection flag here
        }

        private void ProcessMajorMetal()
        {
            majorMetalDelta = majorMetalDelta + Time.deltaTime;
            if (majorMetalDelta >= majorMetalTimer) StopMajorMetal();
        }

        //  Blind effect members
        public void StartBlind()
        {
            blinded = true;
        }

        public void StopBlind()
        {
            blinded = false;
        }

        //  Dash effect members
        public void StartDash()
        {
            dashing = true;
            positionDelta = GameObject.Find("Player").GetComponent<Transform>().position;
        }

        private void StopDash()
        {
            dashing = false;
            //dashDelta = 0f;
        }

        private void ProcessDash()
        {
            distanceDelta = distanceDelta + Vector3.Distance(GameObject.Find("Player").GetComponent<Transform>().position, positionDelta);
            positionDelta = GameObject.Find("Player").GetComponent<Transform>().position;
            if (distanceDelta >= GameObject.Find("Player").GetComponent<Spell_LightStrong>().dashDistance) StopDash();
        }

        // Speed Boost effect members
        public void StartSpeedBoost()
        {
            speedBoost = true;
            // Blind flag here
        }

        private void StopSpeedBoost()
        {
            speedBoost = false;
            speedBoostDelta = 0f;
            // Speed Boost flag code here
        }

        private void ProcessSpeedBoost()
        {
            speedBoostDelta = speedBoostDelta + Time.deltaTime;
            if (speedBoostDelta >= speedBoostTimer) StopSpeedBoost();
        }

        // Updater for the timers
        void Update()
        {
            if (burning) ProcessBurn();
            if (slowed) ProcessSlow();
            if (frozen) ProcessFrozen();
            if (stunned) ProcessStun();
            if (minorMetalProtection) ProcessMinorMetal();
            if (majorMetalProtection) ProcessMajorMetal();
            if (speedBoost) ProcessSpeedBoost();
        }

        private void FixedUpdate()
        {
            if (dashing) ProcessDash();
        }

        private void Start()
        {
            _player = GetComponent<Player_State>();
        }
    }
}

