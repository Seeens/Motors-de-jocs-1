using System.Collections;
using System.Collections.Generic;
using Spell.EffectWrapper;
using UnityEngine;

public class Spell_LightningWeak : MonoBehaviour
{

    private RaycastHit hitCollider;
    private Vector3 originPostion;
    private Vector3 directionCast;

    public void CastLightningWeak()
    {
        originPostion = GetComponent<Transform>().position;
        directionCast = GetComponent<Transform>().forward;
        if (Physics.Raycast(originPostion, directionCast, out hitCollider))
        {
            GameObject colliderCast = hitCollider.collider.gameObject;
            if (colliderCast != this.gameObject && colliderCast.tag == "Player" || colliderCast.tag == "boss")
            {
                //hitCollider.collider.GetComponent<EffectWrapper>().StartBlind();
                //hitCollider.collider.GetComponent<DummyHit>().HitLightningWeak();
            }
        }
    }

    private void Start()
    {
        
    }

}
