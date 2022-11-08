using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetPlayer;
    public Vector3 cameraOffset;
    public Vector3 targetedPosition;
    public float endLoacation;
    public float startLocation;


    private Vector3 velocity = Vector3.zero;
   
    public float moveSmoht;

    private void LateUpdate() {

        if (targetPlayer.transform.position.x < endLoacation && targetPlayer.transform.position.x > startLocation) {
            targetedPosition = targetPlayer.transform.position + cameraOffset;
            transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, moveSmoht);
        }
        else {

        }
    }
}
