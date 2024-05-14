using DG.Tweening;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform endPosition;
    public Transform player;
    public float travelDuration; 
    [Tooltip("Whether the platform should move from point to point repeatedly.")]
    public bool loop;

    private void Awake()
    {
        // Make sure the collider on the platform is a trigger
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true; 
    }

    private void Start()
    {
        // Looping platform 
        if (loop)
        {
            transform.DOMove(endPosition.position, travelDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        }
        // Non-looping platform 
        else if (!loop)
        {
            transform.DOMove(endPosition.position, travelDuration).SetEase(Ease.InOutSine);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.parent = null;
        }
    }
}