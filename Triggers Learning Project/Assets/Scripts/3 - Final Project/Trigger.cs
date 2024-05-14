using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    public GameObject objectToTrigger;
    public Collider triggerCollider;
    [Tooltip("CASE SENSITIVE.")]
    public string triggerObjectTag;
    private ITriggerable scriptToTrigger;

    private void Start()
    {
        // Make sure the collider is set to "isTrigger".
        triggerCollider = GetComponent<Collider>();
        triggerCollider.isTrigger = true;

        // Get the script that will be triggered. 
        scriptToTrigger = objectToTrigger.GetComponent<ITriggerable>();
    }

    // Object entered trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(triggerObjectTag))
        {
            scriptToTrigger.TriggerEntered();
        }
    }

    // Object exited trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(triggerObjectTag))
        {
            scriptToTrigger.TriggerExited();
        }
    }

}