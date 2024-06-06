using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private StoryDialogController dialogController;

    private NpcDialogController npcDialogController;
    // Start is called before the first frame update
    void Start()
    {
        dialogController = GetComponent<StoryDialogController>();
        npcDialogController = GetComponent<NpcDialogController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Primera conversacion planeta de estadistica
        if (EventManager.ValidarEvento("PEJ-51-00"))
        {
            dialogController.DialogCode = "PEST-51-";
            dialogController.CantDialog = 6;
            if (dialogController.finishedTalking)
            {
                EventManager.ModificarEstadoEvento("PEJ-51-00", 1);
            }
        }
        //Si ya hizo el minijuego y no ha hecho la segunda conversaci�n
        else if (!EventManager.ValidarEvento("PEJ-52-00") && EventManager.ValidarEvento("PEJ-51-01"))
        {
            //Se hace la segunda conversaci�n
            dialogController.DialogCode = "PEST-52-";
            dialogController.CantDialog = 2;
            if (dialogController.finishedTalking)
            {
                EventManager.ModificarEstadoEvento("PEJ-51-01", 1);
            }
        }
        //Si ya se hizo el minijuego y ya se hizo la segunda conversacion
        else if (!EventManager.ValidarEvento("PEJ-52-00") && !EventManager.ValidarEvento("PEJ-51-01"))
        {
            EventManager.ModificarEstadoEvento("NAV-61-00", 1);
            dialogController.enabled = false;
            npcDialogController.enabled = true;
            npcDialogController.DialogCode = "PEST-53-";
            npcDialogController.CantDialog = 1;
        }
    }
}
