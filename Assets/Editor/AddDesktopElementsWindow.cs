using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AddDesktopElementsWindow : EditorWindow
{
    //Window Variables
    GameObject windowPrefab;
    Sprite windowSprite;
    string windowName;
    Vector2 windowSize = new Vector2(200, 200);

    //Icon Variables
    GameObject iconPrefab;

    Sprite iconSprite;
    string iconString;
    GameObject iconWindow;

    //Start Menu Item Variables
    GameObject startMenuItemPrefab;

    Sprite itemSprite;
    string itemName;
    GameObject itemWindow;
    bool putOnStartMenu;

    //Notification and Popup Variables
    GameObject notificationPrefab;
    Sprite NotificationSprite;
    string notificationName;
    float notificationLifespan;
    string notificationToolTip;
    bool notificationPopupDespawn;
    float notificationPopupLifespan;
    string notificationPopupTitle;
    string notificationPopupDescription;

    //Sets all the prefabs
    private void OnValidate()
    {
        windowPrefab = (GameObject)Resources.Load("DefaultObjects/Window");
        iconPrefab = (GameObject)Resources.Load("DefaultObjects/Icon");
        startMenuItemPrefab = (GameObject)Resources.Load("DefaultObjects/StartMenuItem");
        notificationPrefab = (GameObject)Resources.Load("DefaultObjects/Notification");
    }

    //Would create an instance of the editor window when it is loaded.
    [MenuItem("Window/Desktop Settings")]
    public static void LoadWindow()
    {
        GetWindow<AddDesktopElementsWindow>("Desktop Settings");
    }

    private void OnGUI()
    {
        //Window Scene
        GUILayout.Label("Window", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Title Bar Sprite:");
        windowSprite = (Sprite)EditorGUILayout.ObjectField(windowSprite, typeof(Sprite), allowSceneObjects: true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Window Name:");
        windowName = EditorGUILayout.TextField("", windowName);
        EditorGUILayout.EndHorizontal();

        windowSize = EditorGUILayout.Vector2Field("Window Size: ", windowSize);

        if (GUILayout.Button("Create Window"))
        {
            //When pressed, the icon will create an instance in the scene.
            if (windowSprite == null)
            {
                Debug.LogWarning("Window Sprite cannot contain an empty field");
            }
            else if (windowName == null)
            {
                Debug.LogWarning("Window Name cannot contain an empty field");
            }
            else
            {
                string path = "Assets/Prefabs/Windows/" + windowName + ".prefab";
                path = AssetDatabase.GenerateUniqueAssetPath(path);

                GameObject tmpWindow = Instantiate(windowPrefab);

                tmpWindow.GetComponent<RectTransform>().sizeDelta = new Vector2(windowSize.x + 4, windowSize.y + 4);
                WindowScript windowScript = tmpWindow.GetComponent<WindowScript>();
                windowScript.titleBarIcon.sprite = windowSprite;
                windowScript.titleBarText.text = windowName;

                PrefabUtility.SaveAsPrefabAsset(tmpWindow, path);

                Destroy(tmpWindow);

                EditorUtility.FocusProjectWindow();
                Selection.activeObject = windowPrefab;
                Debug.Log(":)");
            }
        }

        EditorGUILayout.Space();

        //Icon Settings
        GUILayout.Label("Icon", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Sprite:");
        iconSprite = (Sprite)EditorGUILayout.ObjectField(iconSprite, typeof(Sprite), allowSceneObjects: true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name:");
        iconString = EditorGUILayout.TextField("", iconString);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Window:");
        iconWindow = (GameObject)EditorGUILayout.ObjectField(iconWindow, typeof(GameObject), allowSceneObjects: true);
        EditorGUILayout.EndHorizontal();

        if(GUILayout.Button("Create Icon"))
        {
            //When pressed, the icon will create an instance in the scene.
            if(iconSprite == null)
            {
                Debug.LogWarning("Icon Sprite cannot contain an empty field");
            }
            else if (iconString == null)
            {
                Debug.LogWarning("Icon Name cannot contain an empty field");
            }
            else if (iconWindow == null)
            {
                Debug.LogWarning("Window cannot contain an empty field, create one if you need to.");
            }
            else
            {
                Icon iconScriptableObject = CreateInstance<Icon>();
                iconScriptableObject.iconName = iconString;
                iconScriptableObject.iconSprite = iconSprite;
                iconScriptableObject.window = iconWindow;

                AssetDatabase.CreateAsset(iconScriptableObject, "Assets/ScriptableObjects/Icons/" + iconString + ".asset");
                AssetDatabase.SaveAssets();

                GameObject tmpIcon = Instantiate(iconPrefab);
                IconScript iconScript = tmpIcon.GetComponent<IconScript>();
                iconScript.icon = iconScriptableObject;
                iconScript.transform.parent = ThemeManager.instance.iconSpace.transform;

                EditorUtility.FocusProjectWindow();
                Selection.activeObject = iconScriptableObject;
                Debug.Log(":)");
            }
        }

        EditorGUILayout.Space();

        //Start Menu Item Settings
        GUILayout.Label("Start Menu Item", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Sprite:");
        itemSprite = (Sprite)EditorGUILayout.ObjectField(itemSprite, typeof(Sprite), allowSceneObjects: true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name:");
        itemName = EditorGUILayout.TextField("", itemName);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Window:");
        itemWindow = (GameObject)EditorGUILayout.ObjectField(itemWindow, typeof(GameObject), allowSceneObjects: true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        putOnStartMenu = EditorGUILayout.Toggle("Add to start menu?", putOnStartMenu);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create Start Menu Button"))
        {
            //When pressed, the icon will create an instance in the scene.
            if (itemSprite == null)
            {
                Debug.LogWarning("Item Sprite cannot contain an empty field");
            }
            else if (itemName == null)
            {
                Debug.LogWarning("Item Name cannot contain an empty field");
            }
            else if (itemWindow == null)
            {
                Debug.LogWarning("Window cannot contain an empty field, create one if you need to.");
            }
            else
            {
                StartMenuItem itemScriptableObject = CreateInstance<StartMenuItem>();
                itemScriptableObject.menuName = itemName;
                itemScriptableObject.sprite = itemSprite;
                itemScriptableObject.window = itemWindow;

                AssetDatabase.CreateAsset(itemScriptableObject, "Assets/ScriptableObjects/Start Menu Items/" + itemName + ".asset");
                AssetDatabase.SaveAssets();

                if (putOnStartMenu)
                {
                    StartMenuScript startMenu = ThemeManager.instance.taskbarCanvas.GetComponentInChildren<StartMenuScript>();
                    startMenu.startMenuItems.Add(itemScriptableObject);
                }

                EditorUtility.FocusProjectWindow();
                Selection.activeObject = itemScriptableObject;
                Debug.Log(":)");
            }
        }

        EditorGUILayout.Space();
        //Notification Settings
        GUILayout.Label("Create a new Notification", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Sprite:");
        NotificationSprite = (Sprite)EditorGUILayout.ObjectField(NotificationSprite, typeof(Sprite), allowSceneObjects: true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name:");
        notificationName = EditorGUILayout.TextField("", notificationName);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Lifespan:");
        notificationLifespan = EditorGUILayout.FloatField(notificationLifespan);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Tooltip Text:");
        notificationToolTip = EditorGUILayout.TextField("", notificationToolTip);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        notificationPopupDespawn = EditorGUILayout.Toggle("Despawn?", notificationPopupDespawn);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        GUILayout.Label("Popup Settings", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Popup Lifespan:");
        notificationPopupLifespan = EditorGUILayout.FloatField(notificationPopupLifespan);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Popup Title:");
        notificationPopupTitle = EditorGUILayout.TextField("", notificationPopupTitle);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Popup Description:");
        notificationPopupDescription = EditorGUILayout.TextField("", notificationPopupDescription);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create Notification"))
        {
            //When pressed, the icon will create an instance in the scene.
            if (NotificationSprite == null)
            {
                Debug.LogWarning("Notification Sprite cannot contain an empty field");
            }
            else if (notificationName == null)
            {
                Debug.LogWarning("Notification Name cannot contain an empty field");
            }
            else if (notificationToolTip == null)
            {
                Debug.LogWarning("Tooltip cannot contain an empty field");
            }
            else if (notificationPopupLifespan <= 0)
            {
                Debug.LogWarning("The popup needs to have a lifespan, or to be put on permamently.");
            }
            else if (notificationLifespan <= 0 && !notificationPopupDespawn)
            {
                Debug.LogWarning("Lifespan needs to be greater than 0 or to be on permamently.");
            }
            else if (notificationPopupTitle == null)
            {
                Debug.LogWarning("Notification Popup Title cannot be an empty field");
            }
            else if (notificationPopupDescription == null)
            {
                Debug.LogWarning("Notification Description cannot be an empty field");
            }
            else
            {
                Notification notification = CreateInstance<Notification>();
                
                notification.notificationSprite = NotificationSprite;
                notification.notificationTitle = notificationPopupTitle;
                notification.notificationToolTipText = notificationToolTip;
                notification.notificationText = notificationPopupDescription;
                notification.stayOnPermamently = notificationPopupDespawn;
                notification.notificationLifespan = notificationPopupLifespan;

                AssetDatabase.CreateAsset(notification, "Assets/ScriptableObjects/Notifications/" + notificationName + ".asset");
                AssetDatabase.SaveAssets();

                GameObject tmpNotif = Instantiate(notificationPrefab);
                NotificationObj notifScript = tmpNotif.GetComponent<NotificationObj>();
                notifScript.notification = notification;
                notifScript.transform.parent = ThemeManager.instance.taskbar.GetComponentInChildren<NotificationAreaScript>().NotificationsSpace.transform;

                EditorUtility.FocusProjectWindow();
                Selection.activeObject = notification;
                Debug.Log(":)");
            }
        }
    }
}
