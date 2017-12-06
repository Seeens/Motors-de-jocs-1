using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_FireBall : MonoBehaviour
{

    [SerializeField] private float _spinSpeed = 0.7f;

    /* private Rigidbody _rigidbody; */

    void Start()
    {
        /* _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false; */
    }

    void Update()
    {
        /* Rotate the ball */
        transform.Rotate(Vector3.forward * _spinSpeed + Vector3.up * _spinSpeed, Space.Self);

        /* Scale up to normal scale and enable gravity */
        if (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0.5f * Time.deltaTime);
        }
        /* else if (transform.parent == null)
        {
            _rigidbody.useGravity = true;
        } */
    }
}
