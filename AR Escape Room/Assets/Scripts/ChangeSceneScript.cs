using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    Camera arCam;
    GameObject touchedObject;
    [SerializeField]
    BuildModeScript buildMode;

    // Start is called before the first frame update
    void Start()
    {
        touchedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && touchedObject == null)
            {
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.tag == "Puzzle" && buildMode.buildOrPlay == true)
                    {
                        touchedObject = hit.collider.gameObject;
                        touchedObject.transform.GetChild(0).gameObject.SetActive(true);
                        //touchedObject = null;
                    } else if (hit.collider.gameObject.tag == "Puzzle" && buildMode.buildOrPlay == false)
                    {
                        touchedObject = hit.collider.gameObject;
                    }
                }
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Moved && touchedObject != null && buildMode.buildOrPlay == false)
            {
                touchedObject.transform.position = m_Hits[0].pose.position;
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                touchedObject = null;
            }
        }
        
    }
}
