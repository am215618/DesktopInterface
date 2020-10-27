using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerScript : MonoBehaviour
{
    public Explorer explorer;
    public IconScript iconBase;

    public Icon[] icons;
    GameObject[] visibleIcons;

    void Start()
    {
        icons = explorer.icons;
        visibleIcons = new GameObject[icons.Length];
        for (int i = 0; i < icons.Length; i++)
        {
            visibleIcons[i] = Instantiate(iconBase.gameObject, transform);
            visibleIcons[i].GetComponent<IconScript>().canDrag = false;
        }
    }
}
