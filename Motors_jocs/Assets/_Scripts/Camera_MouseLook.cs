using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Camera_MouseLook : MonoBehaviour
{

    [SerializeField] public float sensitivity = 5.0f;
    [SerializeField] public float smoothing = 2.0f;

    private GameObject _character;

    private Vector2 _mouseLook;
    private Vector2 _smoothV;

    void Start()
    {
        _character = transform.parent.gameObject;
    }

    void Update()
    {
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        _smoothV.x = Mathf.Lerp(_smoothV.x, mouseDelta.x, 1f / smoothing);
        _smoothV.y = Mathf.Lerp(_smoothV.y, mouseDelta.y, 1f / smoothing);
        _mouseLook += _smoothV;

        if (_mouseLook.y < -60) _mouseLook.y = -60;
        if (_mouseLook.y > 60) _mouseLook.y = 60;

        transform.localRotation = Quaternion.AngleAxis(-_mouseLook.y, Vector3.right);
        _character.transform.localRotation = Quaternion.AngleAxis(_mouseLook.x, _character.transform.up);
    }

}
