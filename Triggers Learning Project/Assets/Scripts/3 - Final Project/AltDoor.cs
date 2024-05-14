using UnityEngine;
using DG.Tweening;

public class AltDoor : MonoBehaviour, ITriggerable
{
    [Header("References")]
    [Tooltip("Where the door will be when it is closed.")]
    public Transform closedPosition;
    [Tooltip("Where the door will be when it is open.")]
    public Transform openPosition;

    [Header("Settings")]
    [Tooltip("How long the door will take to open/close. ")]
    public float openingDuration;
    [Tooltip("Whether the door after being opened.")]
    public bool openOnce;

    // Open the door
    public void TriggerEntered()
    {
        transform.DOMove(openPosition.position, openingDuration);
    }

    // Close the door
    public void TriggerExited()
    {
        if (!openOnce)
        {
            transform.DOMove(closedPosition.position, openingDuration);
        }
    }
}
