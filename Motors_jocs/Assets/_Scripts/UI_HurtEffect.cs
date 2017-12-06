using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_HurtEffect : MonoBehaviour
{

    private static float stainUpMax = 1.0f;
    private static float stainUpMin = 0.85f;

    private static float stainUpSpeed = 0.02f;
    private static float stainDownSpeed = 1.5f;

    public static float waitTime = 0.0f;
    public float _textureOpacity = 0.0f;

    [SerializeField] private Player_State _player;
    [SerializeField] private RawImage _image;

    IEnumerator Stain(float aValue, float aTime)
    {
        float alpha = _image.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(_image.color.r, _image.color.g, _image.color.b, Mathf.SmoothStep(alpha, aValue, t));
            _image.color = newColor;
            yield return null;
        }
    }

    IEnumerator Controller()
    {
        StartCoroutine(Stain(_textureOpacity, stainUpSpeed));
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(Stain(0.0f, stainDownSpeed));
    }

    public void StartEffect()
    {
        _textureOpacity = Mathf.Lerp(stainUpMin, stainUpMax, _player.GetHealth() / 100f);
        StartCoroutine(Controller());
    }

    void Start()
    {
        _player = GetComponent<Player_State>();
    }

}
