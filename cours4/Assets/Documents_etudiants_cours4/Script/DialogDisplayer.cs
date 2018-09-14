﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogDisplayer : MonoBehaviour {
    private Text textComponent;
	// Use this for initialization
	void Start () {
        textComponent = gameObject.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void setDialogText(string newDialogText)
    {
        textComponent.text = newDialogText;
    }
    public void closeDialog()
    {
        Destroy(gameObject);
    }
}
