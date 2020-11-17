using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutdownBoxScript : MonoBehaviour
{
    //Closes the application
    public void Shutdown()
    {
        Application.Quit();
    }

    //Disables the shutdown.
    public void DontShutdown()
    {
        Destroy(gameObject);
    }
}
