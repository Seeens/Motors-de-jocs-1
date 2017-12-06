using System.Collections;
using System.Collections.Generic;
using Spell.EffectWrapper;
using UnityEngine;

public class Spell_FireStrong : MonoBehaviour
{

    public float radius = 25f;

    private Collider[] hitColliders;
    private Vector3 playerPosition;
    private MageStats player;

    public void CastFireStrong()
    {
        playerPosition = player.transform.position;
        hitColliders = Physics.OverlapSphere(playerPosition, radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            GameObject colliderCast = hitColliders[i].gameObject;
            if (colliderCast != this.gameObject && colliderCast.tag == "Player" || colliderCast.tag == "boss")
            {
                //hitColliders[i].GetComponent<EffectWrapper>().StartBurn();
                //hitColliders[i].GetComponent<DummyHit>().HitFireStrong();
            }
        }
    }

    void Start()
    {
        player = GetComponent<MageStats>();
    }

}
