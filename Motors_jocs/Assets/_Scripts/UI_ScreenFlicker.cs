using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ScreenFlicker : MonoBehaviour {

    public float firstStart = 0f;
    public float firstlength = 0.8f;
    public float firstEnd = 0.3f;

    public float secondStart = 0.8f;
    public float secondEnd = 0f;
    public float secondlength = 0.9f;

    public float waitDelta = 0.01f;

    private RawImage image;
    private Color baseImageColor;

    void FadeOpacity(float start, float end, float lenght) {
        if (image.color.a == start) {
            for (float i = 0.0f; i < 1.0f; i+=Time.deltaTime*(1/lenght)) {
                image.color = new Color(baseImageColor.r, baseImageColor.g, baseImageColor.b, Mathf.Lerp(start, end, i));
            }
        }
    }

    IEnumerator Calculate() {
        FadeOpacity(firstStart, firstEnd, firstlength);
        yield return new WaitForSeconds(waitDelta);
        FadeOpacity(secondStart, secondEnd, secondlength);
    }

    public void Flicker() {
        Debug.Log("Flickering");
        Calculate();
    }

    void Start () {
        image = GetComponent<RawImage>();
        baseImageColor = image.color;
    }

}
