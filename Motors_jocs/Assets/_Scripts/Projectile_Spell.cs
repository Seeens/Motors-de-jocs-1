using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Spell : MonoBehaviour
{

    [HideInInspector] public string _spellTag;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        /* Get the reference to the GameObject of the collider */
        var _collider = (collision.gameObject);

        if (_collider.tag == "Player")
        {
            var _spellTrigger = _collider.GetComponent<Player_State>();
            _spellTrigger.YieldDamage(10);
        }

        /* Destroy the projectile */
        Destroy(this.gameObject);
    }

    public void SetSpellType(string spell)
    {
        _spellTag = spell;
    }
}
