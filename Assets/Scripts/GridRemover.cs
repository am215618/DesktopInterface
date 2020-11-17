using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridRemover : MonoBehaviour
{
    GridLayoutGroup layoutGroup; //Gets the layout group.
    void Start()
    {
        layoutGroup = GetComponent<GridLayoutGroup>(); //Sets the layout group to the one in the object.
        StartCoroutine(StartDelay());
    }

    //disables the grid after .1f to allow the icons to be dragged around if its enabled.
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(0.1f);
        layoutGroup.enabled = false;
    }
}
