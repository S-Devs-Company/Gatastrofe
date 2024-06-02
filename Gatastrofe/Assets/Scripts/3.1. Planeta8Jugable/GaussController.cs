using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussController : MonoBehaviour
{
    private StoryDialogController dialogController;
    // Start is called before the first frame update
    void Start()
    {
        dialogController = GetComponent<StoryDialogController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventManager.ValidarEvento("PMJ-31-01"))
        {
            dialogController.DialogCode = "PMAT-33-";
            dialogController.CantDialog = 6;
        }
        else if(EventManager.ValidarEvento("PMJ-32-00"))
        {
            dialogController.DialogCode = "PMAT-34-";
            dialogController.CantDialog = 1;
        }
        else
        {
            dialogController.DialogCode = "PMAT-35-";
            dialogController.CantDialog = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (EventManager.ValidarEvento("PMJ-31-01"))
        {
            EventManager.ModificarEstadoEvento("PMJ-31-01", 1);
        }
        
    }
}
