using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pesa2kgController : MonoBehaviour
{
    StoryDialogController storyDialogController;
    NpcDialogController npcDialogController;
    [SerializeField] public GameObject instruccionesMiniJuego;
    // Start is called before the first frame update
    void Start()
    {
        storyDialogController = GetComponent<StoryDialogController>();
        npcDialogController = GetComponent<NpcDialogController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.ValidarEvento("PFJ-41-00") || EventManager.ValidarEvento("PFJ-42-00"))
        {
            storyDialogController.enabled = true;
            npcDialogController.enabled = false;
            storyDialogController.DialogCode = "PFIS-41-";
            storyDialogController.CantDialog = 1;
            if (storyDialogController.finishedTalking)
            {
                EventManager.ModificarEstadoEvento("PFJ-41-00", 1);
                instruccionesMiniJuego.SetActive(true);
                
            }
        }
        else if (!EventManager.ValidarEvento("PFJ-42-00") && EventManager.ValidarEvento("PFJ-41-01"))
        {
            storyDialogController.DialogCode = "PFIS-42-";
            storyDialogController.CantDialog = 2;
            if (storyDialogController.finishedTalking)
            {
                EventManager.ModificarEstadoEvento("PFJ-41-01", 1);
            }
        }
        else if (!EventManager.ValidarEvento("PFJ-41-01"))
        {
            storyDialogController.enabled = false;
            npcDialogController.enabled = true;
            npcDialogController.DialogCode = "PFIS-NPC-";
            npcDialogController.CantDialog = 2;
            EventManager.ModificarEstadoEvento("NAV-61-00", 1);
        }
    }
}
