using System.Collections;
using System.Collections.Generic;
using Spell.EffectWrapper;
using UnityEngine;

public class Spell_LightWeak : MonoBehaviour
{

    private float radius = 1.0f;
    private RaycastHit hitCollider;
    private Vector3 originPostion;
    private Vector3 directionCast;

    public void CastLightWeak()
    {
        originPostion = GetComponent<Transform>().position;
        directionCast = GetComponent<Transform>().forward;
        if (Physics.SphereCast(originPostion, radius, directionCast, out hitCollider))
        {
            GameObject colliderCast = hitCollider.collider.gameObject;
            if (colliderCast != this.gameObject && colliderCast.tag == "Player")
            {
                //hitCollider.collider.GetComponent<EffectWrapper>().StartBlind();
                hitCollider.collider.GetComponent<DummyHit>().HitLightWeak();
            }
        }
    }

    private void Start()
    {

    }
}
