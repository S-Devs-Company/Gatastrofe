using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitanteGeoController : MonoBehaviour
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
        if (EventManager.ValidarEvento("PGC-61-00"))
        {
            dialogController.DialogCode = "PGEO-61-";
            dialogController.CantDialog = 3;
            if (dialogController.finishedTalking)
            {
                EventManager.ModificarEstadoEvento("PGC-61-00", 1);
            }
            else if (EventManager.ValidarEvento("PGC-61-00"))
            {
                dialogController.DialogCode = "PGEO-62-";
                dialogController.CantDialog = 1;
            }
            else
            {
                dialogController.enabled = false;
                npcController.enabled = true;
                npcController.DialogCode = "PGEO-NPC-";
                npcController.CantDialog = 2;
            }

        }
        
    }
}
