using UnityEngine;

public class ItemManipulator : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] float maxGrabDistance = 10f, throwForce = 20f, lerpSpeed = 10f;
    [SerializeField] Transform objectHolder;

    Rigidbody grabbedRB;
    BoxCollider col;

    void Update()
    {
        if (grabbedRB)
        {
            grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.transform.position, Time.deltaTime * lerpSpeed));

            if (Input.GetMouseButtonDown(0))
            {
                grabbedRB.isKinematic = false;
                grabbedRB.AddForce(camera.transform.forward * throwForce, ForceMode.VelocityChange);
                col.isTrigger = false;
                col = null;
                grabbedRB = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedRB)
            {
                grabbedRB.isKinematic = false;
                col.isTrigger = false;
                col = null;
                grabbedRB = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out hit, maxGrabDistance))
                {
                    grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (grabbedRB)
                    {
                        grabbedRB.isKinematic = true;
                        col = hit.transform.gameObject.GetComponent<BoxCollider>();
                        col.isTrigger = true;
                    }
                }
            }
        }
    }
}