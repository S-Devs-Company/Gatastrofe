using TMPro;
using UnityEngine;

public class StoryDialogController : MonoBehaviour
{
    private bool isPlayerInRange = false;
    public bool finishedTalking = false;
    [SerializeField] public string DialogCode;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private GameObject PanelInstrucciones;
    [SerializeField] private TMP_Text DialogueText;
    [SerializeField] public int CantDialog;
    private int counter = 1;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            StartDialogue();
        }
    }

    // Función que inicia el dialogo del NPC de la historia
    private void StartDialogue()
    {
        finishedTalking = false;
        Playable.canPlay = false;
        Playable.isTalking = true;
        DialoguePanel.SetActive(true);
        if (PanelInstrucciones != null)
        {
            PanelInstrucciones.SetActive(false);
        }
        ShowDialogues();
    }

    // Función para saber cuando el NPC de la historia tiene que hablar con el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.isPlayerInRange = false;
        }
    }

    // Función que coloca la linea de dialogo en el Texto
    private void ShowLine(string line)
    {
        DialogueText.text = line;
    }

    // Función que muestra los dialogos
    private void ShowDialogues()
    {
        ShowLine(DialogManager.ObtenerDialogo(DialogCode + counter));
        if (Input.GetButtonDown("Fire1"))
        {
            counter++;
        }
        if (counter > CantDialog)
        {
            finishedTalking = true;
            DialoguePanel.SetActive(false);
            if (PanelInstrucciones != null)
            {
                PanelInstrucciones.SetActive(true);
            }
            isPlayerInRange = false;
            if (EventManager.ValidarEvento("INI-21-00"))
            {
                if (GameObject.Find("cientifico") == gameObject)
                {
                    if (EventManager.ValidarEvento("INI-22-00"))
                    {
                        PlayerTutorial.primerDialogo = true;
                    }
                    else
                    {
                        PlayerTutorial.segundoDialogo = true;
                    }
                }
            }
            else
            {
                Playable.canPlay = true;
                Playable.isTalking = false;
            }
            counter = 1;
        }
    }
}
