using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public PlacementIndicatorScript IndicatorScript;
    public GameObject objectToReplace;
    public GameObject puzzleToReplace;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(activatePlacement);
    }

    private void activatePlacement()
    {
        IndicatorScript.placementIndicatorIsActive = true;
        IndicatorScript.objectToPlace = objectToReplace;
        IndicatorScript.puzzleToPlace = puzzleToReplace;
    }
    
}
