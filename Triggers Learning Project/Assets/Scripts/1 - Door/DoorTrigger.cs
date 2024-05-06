using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Renderer))]
[RequireComponent (typeof(Rigidbody))]
public class DoorPressurePlate : MonoBehaviour
{
    #region Variables
    [Tooltip("CASE SENSITIVE.The tag of the object that will trigger this thing upon collision.")]
    public string objectTag;
    [Tooltip("The door this trigger will open.")]
    public Door door;
    [Tooltip("Does the door close if nothing is in the trigger zone.")]
    public bool changeStateOnExit;
    [Tooltip("Color of the pressure pad without an object on it.")]
    public Color unpressedColor;
    [Tooltip("Color of the pressure pad with an object on it.")]
    public Color pressedColor;
    public float compressionDistance;
    public float compressionMotionDuration;

    Renderer _renderer; 
    #endregion

    #region Setup
    private void Start()
    {
        // Get renderer component 
        _renderer = GetComponent<Renderer>();
        // Set color of pressure pad to be unpressed color 
        _renderer.material.color = unpressedColor;

        // Get collider component 
        Collider collider = GetComponent<Collider>();
        if (collider != null )
        {
            if (!collider.isTrigger)
            {
                // Make sure the collider is a trigger 
                collider.isTrigger = true;
            }
        }

        // Disable rigidbody gravity so collisions work
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }
    #endregion

    #region Trigger Door Open & Close
    // Trigger door opening 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(objectTag))
        {
            // Open the door
            door.Open();
            // Move the pressure plate down 
            transform.DOMoveY(transform.position.y - compressionDistance, compressionMotionDuration);
            // Set color of pressure pad to be pressed color
            _renderer.material.color = pressedColor;
        }
    }

    // Trigger door closing 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(objectTag))
        {
            if (changeStateOnExit)
            {
                // Close the door
                door.Close();
               
            }

            // Move the pressure plate back to normal position
            transform.DOMoveY(transform.position.y + compressionDistance, compressionMotionDuration);
            // Set color of pressure pad to be pressed color
            _renderer.material.color = unpressedColor;
        }
    }
    #endregion
}