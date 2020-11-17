using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEditor;

public class NotesScript : MonoBehaviour
{
    //Variables
    InputField inputArea;

    public GameObject OpenDialog;
    public GameObject SaveDialog;

    string[] textFiles;
    public GameObject TextDocButton;
    GameObject[] textButtonObjects;

    public string fileName;
    TextAsset textFile;

    // Gets the inputfield.
    void Start()
    {
        inputArea = GetComponentInChildren<InputField>();
    }

    //Makes the document Blank.
    public void New()
    {
        inputArea.text = "";
    }

    //This launch an in-game dialog box that lists literally all the files in the folder specified.
    //In Editor this would include the meta files.
    public void Open()
    {
        OpenDialog.SetActive(true);
        textFiles = Directory.GetFiles(Application.dataPath + "/Resources/TextFiles/"); /* Gets all the files */

        //This makes the length of the objects the same as the number of files.
        textButtonObjects = new GameObject[textFiles.Length];
        //This function loops through every text button object and creates a button for each of the files inside the folder.
        for (int i = 0; i < textButtonObjects.Length; i++)
        {
            textButtonObjects[i] = Instantiate(TextDocButton, OpenDialog.GetComponentInChildren<GridLayoutGroup>().transform);
            textButtonObjects[i].GetComponentInChildren<Text>().text = Path.GetFileName(textFiles[i]);
        }
    }

    //This actually opens the document.
    public void OpenDocument(string nameOfFile)
    {
        //Sets the text inside the textfield to null.
        inputArea.text = null;

        //Opens the file.
        string path = Application.dataPath + "/Resources/TextFiles";
        string fileName = nameOfFile;

        //This reads the file.
        StreamReader reader = new StreamReader(path + "/" + fileName);

        //Then it outputs the file into the text editor.
        inputArea.text = reader.ReadToEnd();
        reader.Close();
        CancelOpen();
    }

    //In a nutshell, this closes the file, and nullifies all the buttons.
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
        SaveDialog.SetActive(true);
    }

    public void SaveDocument()
    {
        //Need to ask Joseph about a better way to write this code
        //be careful, dont allow backslashes. (or anything else illegal)
        fileName = SaveDialog.GetComponentInChildren<InputField>().text + ".txt";
        string path = Application.dataPath + "/Resources/TextFiles/";

        //Creates the directory if it doesnt exist.
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        //Deletes the original file
        File.Delete(path + fileName);
        //Writes the data in the file into the new text document
        StreamWriter writer = new StreamWriter(path + fileName, true);
        writer.Write(inputArea.text);
        writer.Close();

        //Loads the text file just saved then closes the dialog.
        Resources.Load(path + fileName);
        textFile = (TextAsset)Resources.Load(fileName);
        SaveDialog.SetActive(false);
    }

    //Closes the dialog.
    public void CancelSave()
    {
        SaveDialog.SetActive(false);
    }
}
