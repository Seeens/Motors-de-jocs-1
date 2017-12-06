using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spell.EffectWrapper;

public class Spell_LightStrong : MonoBehaviour {

    private RaycastHit frontRayCast;
    private EffectWrapper effectManager;
    public float dashDistance;


    void TriggerDash() {
        if (Physics.Raycast(transform.position, transform.forward, out frontRayCast, dashDistance)) dashDistance = Mathf.Round(frontRayCast.distance);
        effectManager.StartDash();
    }
	
	void Update () {
        if (Input.GetKeyDown("space")) {
            Debug.Log("has intentat dashear!");
            TriggerDash();
        }
    }

    void Start() {
        effectManager = GameObject.Find("Player").GetComponent<EffectWrapper>();
        dashDistance = effectManager.dashDistance;
    }
}
