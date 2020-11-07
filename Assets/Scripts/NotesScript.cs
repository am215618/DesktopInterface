using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class NotesScript : MonoBehaviour
{
    InputField inputArea;

    public GameObject OpenDialog;
    public GameObject SaveDialog;

    Object[] textFiles;
    public GameObject TextDocButton;
    GameObject[] textButtonObjects;

    public string fileName;
    TextAsset textFile;

    // Start is called before the first frame update
    void Start()
    {
        inputArea = GetComponentInChildren<InputField>();
    }

    public void New()
    {
        //If file is not different:
        //Check if you want to save
        //Else:
        //Make the document blank.
        inputArea.text = "";
    }

    public void Open()
    {
        //If file is not different:
        //Check if you want to save
        //Else:
        //Load a list of text files in the Resources Folder.
        OpenDialog.SetActive(true);
        textFiles = Resources.LoadAll("TextFiles", typeof(TextAsset));

        textButtonObjects = new GameObject[textFiles.Length];
        for (int i = 0; i < textButtonObjects.Length; i++)
        {
            textButtonObjects[i] = Instantiate(TextDocButton, OpenDialog.GetComponentInChildren<GridLayoutGroup>().transform);
            textButtonObjects[i].GetComponentInChildren<Text>().text = textFiles[i].name;
        }
    }

    public void OpenDocument(string nameOfFile)
    {
        inputArea.text = null;

        string path = "Assets/Resources/TextFiles/" + nameOfFile + ".txt";
        StreamReader reader = new StreamReader(path);

        inputArea.text = reader.ReadToEnd();
        reader.Close();
        CancelOpen();
    }

    public void CancelOpen()
    {
        textFiles = null;
        for (int i = 0; i < textButtonObjects.Length; i++)
        {
            Destroy(textButtonObjects[i]);
        }
        textButtonObjects = null;
        OpenDialog.SetActive(false);
    }

    public void Save()
    {
        //Load a dialog allows you to save a file.
        //The dialog would contain:
        //-> A list of text documents in the Resources Folder.
        //-> Somewhere to change the file name
        //-> save as scripts?
        SaveDialog.SetActive(true);
    }

    public void SaveDocument()
    {
        //Need to ask Joseph about a better way to write this code
        fileName = SaveDialog.GetComponentInChildren<InputField>().text;
        string path = "Assets/Resources/TextFiles/" + fileName + ".txt";
        File.Delete(path);
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(inputArea.text);
        writer.Close();

        AssetDatabase.ImportAsset(path);
        textFile = (TextAsset)Resources.Load(fileName);
        SaveDialog.SetActive(false);
    }

    public void CancelSave()
    {
        SaveDialog.SetActive(false);
    }
}
