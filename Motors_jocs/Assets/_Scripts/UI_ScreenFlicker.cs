using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ScreenFlicker : MonoBehaviour {

    public float start;
    public float end;
    public float length;

    private RawImage image;
    private Color baseImageColor;

    void FadeOpacity(float start, float end, float lenght) {
        if (image.color.a == start) {
            for (float i = 0.0f; i < 1.0f; i+=Time.deltaTime*(1/length)) {
                image.color = new Color(baseImageColor.r, baseImageColor.g, baseImageColor.b, Mathf.Lerp(start, end, i));
            }
        }
    }

    IEnumerator Calculate() {
        FadeOpacity(0, 0.8f, 0.5f);
        yield return new WaitForSeconds(0.01f);
        FadeOpacity(0.8f, 0, 0.5f);
    }

    public void Flicker() {
        Debug.Log("Tried to flicker");
        Calculate();
    }

    void Start () {
        start = 0.8f;
        end = 0.5f;
        length = 100f;
        image = GetComponent<RawImage>();
        baseImageColor = image.color;
    }

}
