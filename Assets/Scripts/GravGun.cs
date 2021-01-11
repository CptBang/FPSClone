using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravGun : MonoBehaviour
{
    public Transform floatLocation;
    public float floatSpeed = 15f;
    public float launchSpeed = 30f;
    public float gravRange = 15f;
    public Camera fpsCam;

    Rigidbody targetRb;
    bool isAttracting;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            isAttracting = true;
        else if (Input.GetMouseButtonUp(0))
            isAttracting = false;

        if (isAttracting) {
            if (Input.GetMouseButtonDown(1))
                Throw();
            else
                Attract();
        } else
            Release();
    }

    private void Attract() {
        if (targetRb == null) {
            RaycastHit hit;

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, gravRange)) {
                Debug.Log(hit.transform.name);

                Grabbable gr = hit.transform.GetComponent<Grabbable>();
                if (gr != null && gr.isGrabbable) {
                    targetRb = hit.transform.GetComponent<Rigidbody>();
                    targetRb.useGravity = false;
                }
            }
        }
        else
            targetRb.transform.position = Vector3.MoveTowards(targetRb.transform.position, floatLocation.position, floatSpeed * Time.deltaTime);
    }

    private void Release() {
        if (targetRb != null) {
            targetRb.useGravity = true;
            targetRb = null;
        }
    }

    private void Throw() {
        if (targetRb != null) {
            targetRb.useGravity = true;
            targetRb.AddForce(floatLocation.transform.forward*launchSpeed, ForceMode.Impulse);
            targetRb = null;
        }
    }
}
