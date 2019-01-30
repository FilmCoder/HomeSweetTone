using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeInAlpha : MonoBehaviour
{

    public float fadeInStartTime;
    readonly float FADE_DURATION = 2f;
    bool fadeStarted = false;
    Text text;

    // Start is called before the first frame update
    void Start() {
        text = GetComponent<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0); // start alpha at 0
    }

    // Update is called once per frame
    void Update() {
        if(!fadeStarted && Time.timeSinceLevelLoad > fadeInStartTime) {
            fadeStarted = true;
            StartCoroutine(FadeInText());
        }
    }

    IEnumerator FadeInText() {
        float lerpFraction = 0;
        float timeElapsed = 0;

        while (lerpFraction < 1) {
            timeElapsed += Time.deltaTime;
            lerpFraction = timeElapsed / FADE_DURATION;
            text.color = new Color(text.color.r, text.color.g, text.color.b, lerpFraction);
            yield return null;
        }

        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    }
}
