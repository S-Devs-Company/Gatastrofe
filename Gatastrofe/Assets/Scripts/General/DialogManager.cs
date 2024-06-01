using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using System.Collections;
public class DialogManager : MonoBehaviour
{
    private const string ruta = "Assets\\Files\\DialogManager.txt"; // Constante que guarda la ruta de donde se leen los dialogos del juego
    readonly Dictionary<string, string> DialogDictionary = new(); // Diccionario que almacena los dialogos del juego por <Codigo,Dialogo>
     private bool isPlayerInRange=false;
    
    
    
    [SerializeField] private static string DialogLine;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText;
    [SerializeField] private int CantDialog;
    private int counter=1;
    
    // Update is called once per frame

    // Metodo para que no se destruya el objeto una vez se cambia de escena
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
        
        DialoguePanel.SetActive(true);
      
        
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

private void ShowLine(string line)
    {
        DialogueText.text = line;
    }

    private void ShowDialogues()
    {
         


        if(Input.GetButtonDown("Fire1")){
        
            ShowLine(ObtenerDialogo(DialogLine+counter));
            // You can add a delay here if you want to simulate waiting
        counter++;
        }
        if(counter>CantDialog){
              
             DialoguePanel.SetActive(false);
             counter=1;
        }
      
    }




    // Lee el archivo de DialogManager para cargar la lista de dialogos en el diccionario
    public void LeerArchivo()
    {
        using (StreamReader reader = new StreamReader(ruta))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                
                string[] parts = line.Split(";");
                DialogDictionary.Add(parts[0], parts[1]);
            }

        }
    }
 
    // Retorna el dialogo con el codigo ingresado
    public string ObtenerDialogo(string codigoDialogo) => DialogDictionary[codigoDialogo];

  

}
