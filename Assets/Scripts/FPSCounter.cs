using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This will display the FPS of the game in real time.
public class FPSCounter : MonoBehaviour
{
    int averageFrameRate;
    Text fpsText;
    float timer;
    float refresh = 0.1f;
    string display = "{0} FPS";

    private void Start()
    {
        fpsText = GetComponent<Text>();

        if (!Debug.isDebugBuild)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
    }

    void Update()
    {
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0)
            averageFrameRate = (int)(1f / timelapse);

        fpsText.text = string.Format(display, averageFrameRate.ToString());
    }
}
