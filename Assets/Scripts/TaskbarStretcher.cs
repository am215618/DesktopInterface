using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskbarStretcher : MonoBehaviour
{
    Resolution res;
    // Start is called before the first frame update

    private void OnValidate()
    {
        if (res.width != Screen.width || res.height != Screen.height)
        {
            res = Screen.currentResolution;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(res.width, gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
    }

    void Start()
    {
        if (res.width != Screen.width || res.height != Screen.height)
        {
            res = Screen.currentResolution;
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(res.width, gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
    }
}
