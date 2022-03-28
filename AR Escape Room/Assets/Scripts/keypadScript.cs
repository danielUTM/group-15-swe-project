using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keypadScript : MonoBehaviour
{
    public GameObject buildModeObject;

    private AudioBehaviour audioScript;
    private TMPro.TextMeshProUGUI textToChange;
    private string correctString;
    private string codeSequence;

    // Start is called before the first frame update
    void Start()
    {
        codeSequence = "";
        buttonPush.ButtonPressed += AddDigitToCodeSequence;
        audioScript = gameObject.GetComponentInChildren<AudioBehaviour>();
        correctString = audioScript.correctKey;
        textToChange = gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        textToChange.text = codeSequence;

        buildModeObject = GameObject.FindGameObjectWithTag("NumPuzzle");
    }

    private void AddDigitToCodeSequence(string digitEntered)
    {
        switch (digitEntered)
        {
            case "OK":
                if (codeSequence == correctString)
                {
                    buildModeObject.GetComponent<BuildModeScript>().numOfPuzzles--;
                    Destroy(gameObject.transform.parent.gameObject);
                }
                else
                {
                    codeSequence = "";
                    textToChange.text = codeSequence;
                }
                break;
            case "C":
                codeSequence = "";
                textToChange.text = codeSequence;
                break;
            default:
                if (codeSequence.Length < 3)
                {   
                    codeSequence += digitEntered;
                    textToChange.text = codeSequence;
                }
                break;
        }

    }
    public void goBack()
    {
        gameObject.SetActive(false);
    }
}
