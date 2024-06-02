using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatemagoHistoriaController : MonoBehaviour
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
        if (EventManager.ValidarEvento("PMJ-31-00"))
        {
            dialogController.DialogCode = "PMAT-31-";
            dialogController.CantDialog = 3;
        }
        else if (EventManager.ValidarEvento("PMJ-31-01"))
        {
            dialogController.DialogCode = "PMAT-32-";
            dialogController.CantDialog = 1;
        }
        else
        {
            dialogController.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EventManager.ModificarEstadoEvento("PMJ-31-00", 1);
    }
}
