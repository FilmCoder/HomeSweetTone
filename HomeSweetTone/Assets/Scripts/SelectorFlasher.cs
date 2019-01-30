using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SelectorFlasher : MonoBehaviour
{
    public float rateOfFlash = 0.25f;
    public float flashPause = 0.5f;
    private const float MAX_ALPHA = 0.25f;
    private STATE curState = STATE.UP;
    private float accumulatedTime = 0f;
    public enum STATE {
        UP,
        DOWN,
        PAUSE
    };

    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float alpha;
        switch (curState) {
            case STATE.UP:
                alpha = Mathf.Lerp(0, MAX_ALPHA, accumulatedTime / rateOfFlash);
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
                accumulatedTime += Time.deltaTime;
                if (accumulatedTime >= rateOfFlash) {
                    accumulatedTime = 0;
                    curState = STATE.DOWN;
                }
                break;
            case STATE.DOWN:
                alpha = Mathf.Lerp(MAX_ALPHA, 0, accumulatedTime / rateOfFlash);
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
                accumulatedTime += Time.deltaTime;
                if (accumulatedTime >= rateOfFlash) {
                    accumulatedTime = 0;
                    curState = STATE.PAUSE;
                }
                break;
            case STATE.PAUSE:
                accumulatedTime += Time.deltaTime;
                if (accumulatedTime >= flashPause) {
                    accumulatedTime = 0;
                    curState = STATE.UP;
                }
                break;
        }
    }
}
