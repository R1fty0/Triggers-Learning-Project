using UnityEngine;
using DG.Tweening;
public class Door : MonoBehaviour
{
    #region Variables
    [Tooltip("Refeence to the door.")]
    public Transform door;
    [Tooltip("Where the door will be when it is closed.")]
    public Transform doorClosedTransform;
    [Tooltip("Where the door will be when it is open.")]
    public Transform doorOpenTransform;
    [Tooltip("How long the door will take to open/close.")]
    public float doorAnimationLength;
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            Close();
        }
        if (Input.GetKeyDown("o"))
        {
            Open();
        }
    }

    #region Door Open/Close
    // Open the door
    public void Open()
    {
        door.DOMove(doorOpenTransform.position, doorAnimationLength);
    }

    // Close the door
    public void Close()
    {
        door.DOMove(doorClosedTransform.position, doorAnimationLength);
    }
    #endregion
}