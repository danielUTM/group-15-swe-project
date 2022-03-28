using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System;

public class PlacementIndicatorScript : MonoBehaviour
{
    [SerializeField]
    BuildModeScript numOfPuzzles;

    public GameObject placementIndicator;
    public GameObject objectToPlace;
    public GameObject puzzleToPlace;
    GameObject objectCreated;

    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private ARRaycastManager rayCastMgr;

    public bool placementIndicatorIsActive = false;
    private bool placementPoseIsValid = false;

    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        rayCastMgr = arOrigin.GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementPoseIsValid && placementIndicatorIsActive && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && numOfPuzzles.numOfPuzzles <= 6)
        {
            objectCreated = GameObject.Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
            var puzzleCreated = GameObject.Instantiate(puzzleToPlace);
            puzzleCreated.SetActive(false);
            puzzleCreated.transform.SetParent(objectCreated.transform);
            numOfPuzzles.numOfPuzzles++;
            placementIndicatorIsActive = false;
        }
    }

    private void UpdatePlacementIndicator()
    {
        if(placementPoseIsValid && placementIndicatorIsActive && numOfPuzzles.numOfPuzzles<= 6)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        } else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCentre = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        rayCastMgr.Raycast(screenCentre, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }

    }
}
