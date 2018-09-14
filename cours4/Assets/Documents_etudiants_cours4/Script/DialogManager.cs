using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {
    [SerializeField] public GameObject dialogPrefab;
    [SerializeField] public GameObject mainCanvas;

    private bool actionAxisInUse = true;
    private GameObject player;
    private bool diaglogIsInitiate = false;
    private DialogText currentDialog;
    private DialogDisplayer currentDialogDisplayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        ProcessInput();
    }

    public void StartDialog(DialogText newDialog)
    {
        diaglogIsInitiate = true;
        player.GetComponent<PlayerMovement>().DisableControl();
        currentDialog = newDialog;
        GameObject currentDialogObject = Instantiate(dialogPrefab,mainCanvas.transform);
        currentDialogDisplayer = currentDialogObject.GetComponent<DialogDisplayer>();
        currentDialogDisplayer.setDialogText(currentDialog.GetDialogText());
    }

    public void ProcessInput()
    {
        if (ShouldProcessInput())
        {
            actionAxisInUse = true;
            if (currentDialog.IsNextDialog())
            {
                currentDialog = currentDialog.GetNextDialog();
                currentDialogDisplayer.setDialogText(currentDialog.GetDialogText());
            }
            else
            {
                EndDialog();
            }
        }
    }
    public void EndDialog()
    {
        diaglogIsInitiate = false;
        currentDialogDisplayer.closeDialog();
        player.GetComponent<PlayerMovement>().EnableControl();
        currentDialog = null;
    }

    private bool ShouldProcessInput()
    {
        if (diaglogIsInitiate)
        {
            if(!actionAxisInUse && Input.GetAxis("Jump") != 0)
            {
                return true;
            }
        }
        return false;
    }
    private void ValideAxisInput()
    {

        if(Input.GetAxis("Jump") != 0)
        {
            actionAxisInUse = true;
        }
        else
        {
            actionAxisInUse = false;
        }
    }
}
