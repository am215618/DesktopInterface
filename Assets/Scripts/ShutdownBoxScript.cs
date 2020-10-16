using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutdownBoxScript : MonoBehaviour
{
    public void Shutdown()
    {
        Application.Quit();
    }

    public void DontShutdown()
    {
        Destroy(gameObject);
    }
}
