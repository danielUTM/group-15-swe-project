using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class buttonPush : MonoBehaviour
{
    public static event Action<string> ButtonPressed = delegate { };

    private int dividerPosition;
    public string buttonName, buttonValue;
    // Start is called before the first frame update
    void Start()
    {
        buttonName = gameObject.name;
        dividerPosition = buttonName.IndexOf("-");
        buttonValue = buttonName.Substring(dividerPosition + 1);

        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        ButtonPressed(buttonValue);
    }

    
}
