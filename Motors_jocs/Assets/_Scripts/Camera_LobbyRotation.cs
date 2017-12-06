using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_LobbyRotation : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 22.5f;

    private bool _rotRunning = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rotRunning = !_rotRunning;
        }

        if (_rotRunning)
        {
            KeepRotating();
        }
    }

    public void StartRotating()
    {
        _rotRunning = true;
    }

    public void StopRotating()
    {

        /* Stop the rotation and set the rotation values to 0 */
        _rotRunning = false;
        transform.localRotation.Set(0, 0, 0, transform.localRotation.w);
    }

    private void KeepRotating()
    {
        /* Apply rotation */
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
    }

}
