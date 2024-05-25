using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private const string ruta = "Assets\\Files\\DialogManager.txt"; // Constante que guarda la ruta de donde se leen los dialogos del juego
    readonly Dictionary<string, string> DialogDictionary = new(); // Diccionario que almacena los dialogos del juego por <Codigo,Dialogo>

    // Metodo para que no se destruya el objeto una vez se cambia de escena
    private void Awake()
    {
        DontDestroyOnLoad(this);
        LeerArchivo();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
