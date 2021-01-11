using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravGun : MonoBehaviour
{
    public Transform floatLocation;
    public float launchSpeed = 30f;
    public float gravRange = 15f;
    public Camera fpsCam;

    Target target;
    Rigidbody targetRig;
    bool isAttracting;
    bool isLaunching;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            isAttracting = true;
        else if (Input.GetMouseButtonUp(0))
            isAttracting = false;

        if (isAttracting) {
            if (Input.GetMouseButtonDown(1))
                isLaunching = true;
        }
    }

    private void FixedUpdate() {
        if (isAttracting)
            Attract();
        else if (!isAttracting)
            Release();
        if (isLaunching)
            Throw();
    }

    private void Attract() {
        RaycastHit hit;

        if (target == null) {
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, gravRange)) {
                Debug.Log(hit.transform.name);

                target = hit.transform.GetComponent<Target>();
                if (target != null) {
                    targetRig = target.GetComponent<Rigidbody>();
                    targetRig.useGravity = false;
                    target.transform.position = Vector3.MoveTowards(target.transform.position, floatLocation.position, 0.3f);
                }
            }
        }
        else
            target.transform.position = Vector3.MoveTowards(target.transform.position, floatLocation.position, 0.3f);
    }

    private void Release() {
        if (target != null) {
            targetRig.useGravity = true;
            target = null;
        }
    }

    private void Throw() {
        if (targetRig != null) {
            targetRig.useGravity = true;
            targetRig.AddForce(floatLocation.transform.forward*launchSpeed, ForceMode.Impulse);
            target = null;
            isLaunching = false;
        }
    }
}
