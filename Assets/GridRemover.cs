using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridRemover : MonoBehaviour
{
    GridLayoutGroup layoutGroup;
    void Start()
    {
        layoutGroup = GetComponent<GridLayoutGroup>();
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(0.1f);
        layoutGroup.enabled = false;
    }
}
