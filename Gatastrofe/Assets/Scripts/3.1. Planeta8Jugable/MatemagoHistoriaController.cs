using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatemagoHistoriaController : MonoBehaviour
{
    private StoryDialogController dialogController;
    private NpcDialogController npcController;

    // Start is called before the first frame update
    void Start()
    {
        npcController = GetComponent<NpcDialogController>();
        dialogController = GetComponent<StoryDialogController>();
        dialogController.enabled = true;
        npcController.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.ValidarEvento("PMJ-31-00"))
        {
            dialogController.DialogCode = "PMAT-31-";
            dialogController.CantDialog = 3;
            if (dialogController.finishedTalking)
            {
                EventManager.ModificarEstadoEvento("PMJ-31-00", 1);
            }
        }
        else if (EventManager.ValidarEvento("PMJ-31-01"))
        {
            dialogController.DialogCode = "PMAT-32-";
            dialogController.CantDialog = 1;
        }
        else
        {
            dialogController.enabled = false;
            npcController.enabled = true;
            npcController.DialogCode = "PMAT-NPC-";
            npcController.CantDialog= 2;
        }
    }

   
}
