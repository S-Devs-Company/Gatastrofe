using TMPro;
using UnityEngine;

public class NpcDialogController : MonoBehaviour
{
    private static bool isPlayerInteracting = false; // Variable que verifica si el jugador interactua con el NPC
    [SerializeField] public string DialogCode; // Codigo de los dialogos que tiene el NPC
    [SerializeField] private GameObject DialoguePanel; // Panel donde se muestran los dialogos
    [SerializeField] private TMP_Text DialogueText; // Texto donde se ponen los dialogos
    [SerializeField] public int CantDialog; // Cantidad de dialogos que tiene el NPC
    private int dialogChosen = 1;
    private int counter = 1;

    // Start is called before the first frame update
    void Start()
    {
        dialogChosen = ObtenerDialogoRandom();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInteracting)
        {
            StartDialogue();
        }
    }

    // Función que inicia el dialogo del NPC
    private void StartDialogue()
    {
        DialoguePanel.SetActive(true);
        ShowDialogues();
    }

    // Función que coloca la linea de dialogo en el Texto
    private void ShowLine(string line)
    {
        DialogueText.text = line;
    }

    // Función que muestra los dialogos
    private void ShowDialogues()
    {
        ShowLine(DialogManager.ObtenerDialogo(DialogCode + dialogChosen));
        if (Input.GetButtonDown("Fire1"))
        {
            counter++;
        }
        if (counter > 1)
        {
            DialoguePanel.SetActive(false);
            dialogChosen = ObtenerDialogoRandom();
            counter = 1;
            SetInteraction(false);
        }
    }

    // Función para cambiar el estado de interacción del personaje con el NPC
    public static void SetInteraction(bool interact)
    {
        isPlayerInteracting = interact;
    }

    // FUnción para escoger un dialogo random del NPC
    private int ObtenerDialogoRandom()
    {
        return Random.Range(1, CantDialog + 1);
    }
}
