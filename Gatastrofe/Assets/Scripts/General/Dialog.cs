using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using System.Collections;
public class Dialog : MonoBehaviour
{

    private const string ruta = "Assets\\Files\\DialogManager.txt"; // Constante que guarda la ruta de donde se leen los dialogos del juego
    private static Dictionary<string, string> DialogDictionary = new Dictionary<string, string>(); // Diccionario que almacena los dialogos del juego por <Codigo,Dialogo>
    private static ArrayList lista=new ArrayList();
    private bool isPlayerInRange=false;
    private bool didDialogStart=false;
    private int lineIndex;
    private int counter=0;
    [SerializeField] private static string[] DialogLine;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText;
    // Update is called once per frame
      void Start() {

        DontDestroyOnLoad(this);
        LeerArchivo();
    }
    void Update()
    {
        if (isPlayerInRange)
        {
            
                StartDialogue();
            
        }
    }


    private void StartDialogue()
    {
        didDialogStart = true;
        DialoguePanel.SetActive(true);
      
        lineIndex = 0;
        ShowDialogues();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            this.isPlayerInRange = true;
            Debug.Log("puede interacturar");
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.isPlayerInRange = false;
            Debug.Log("no puede interacturar");
        }
    }

    public static void LeerArchivo()
    {
        StreamReader reader = new StreamReader(ruta);
        string line;
        List<string> dialogLinesList = new List<string>();
        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split(';');
            if (parts.Length >= 2)
            {
               lista.Add(parts[1]);
                DialogDictionary.Add(parts[0], parts[1]);
            }
        }
        DialogLine = dialogLinesList.ToArray();
    }


    private void ShowLine(string line)
    {
        DialogueText.text = line;
    }

    private void ShowDialogues()
    {

        if(Input.GetButtonDown("Fire1")&&counter<=6){
        
            ShowLine(lista[counter].ToString());
            // You can add a delay here if you want to simulate waiting
        counter++;
        }
        if(counter>6){
              didDialogStart = false;
             DialoguePanel.SetActive(false);
        }
      
    }

  
}