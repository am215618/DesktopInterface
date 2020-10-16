using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database", menuName = "Database")]
public class Database : ScriptableObject, ISerializationCallbackReceiver
{
    public StartMenuItem[] startMenuItems;

    public void UpdateID()
    {
        for (int i = 0; i < startMenuItems.Length; i++)
        {
            if(startMenuItems[i].buttonID != i)
            {
                startMenuItems[i].buttonID = i;
            }
        }
    }

    public void OnAfterDeserialize()
    {
        UpdateID();
    }

    public void OnBeforeSerialize()
    {
    }
}
