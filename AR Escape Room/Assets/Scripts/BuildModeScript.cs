using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class BuildModeScript : MonoBehaviour
{
    public bool buildOrPlay = false; //False = build, true = play
    public int numOfPuzzles = 0;
    public GameObject menuOfBuildMode;
    public GameObject ArSeshOr;

    private void Start()
    {
        gameObject.SetActive(true);
        menuOfBuildMode = GameObject.FindGameObjectWithTag("BuildBar");
        menuOfBuildMode.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (buildOrPlay == true)
        {
            menuOfBuildMode.SetActive(false);
        }

        if (numOfPuzzles == 0 && buildOrPlay == true)
        {
            SceneManager.LoadScene("Hello", LoadSceneMode.Single);
        }
    }

    public void changeToPlayMode()
    {
        if (numOfPuzzles > 0) {
            buildOrPlay = true;
            ArSeshOr.GetComponent<ARPlaneManager>().enabled = !ArSeshOr.GetComponent<ARPlaneManager>().enabled;
        }
    }
}
