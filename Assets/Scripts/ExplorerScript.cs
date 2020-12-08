using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerScript : MonoBehaviour
{
    public Explorer explorer; //Explorer Properties
    public GameObject iconBase; //base for the icon

    public List<Icon> icons; //List of icons which are inherited from the explorer properties
    GameObject[] visibleIcons; //list of visible game objects.

    public GameObject TaskbarObject;
    GameObject instancedTaskbarObj;

    void Start()
    {
        icons = explorer.icons;
     
        visibleIcons = new GameObject[icons.Count];
        for (int i = 0; i < icons.Count; i++)
        {
            //Sets the visible icons to an instansiated icon base, then define their properties.
            visibleIcons[i] = Instantiate(iconBase.gameObject, transform);
            visibleIcons[i].GetComponent<IconScript>().icon = icons[i];
            visibleIcons[i].GetComponent<IconScript>().window = icons[i].window;
            visibleIcons[i].GetComponent<IconScript>().canDrag = false;
        }
    }
}
