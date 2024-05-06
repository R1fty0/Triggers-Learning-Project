using DG.Tweening;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [Header("References")]
    public Transform groundFloor;
    public Transform topFloor;
    public Door leftDoor;
    public Door rightDoor;

    [Header("Settings")]
    [Tooltip("How long the elevator will take to travel between floors. ")]
    public float travelDuration;
    [Tooltip("What floor the elevator starts it.")]
    public StartingFloor startingFloor;

    #region Cache
    // The floor the elevator should be at. 
    private Transform targetFloor;
    private float timeForDoorsToClose; 

    #endregion

    public void Awake()
    {
        timeForDoorsToClose = leftDoor.doorAnimationLength + rightDoor.doorAnimationLength;
        PositionSetup();
    }

    public void PositionSetup()
    {
        // Teleport the elevator to the correct starting floor
        if (startingFloor == StartingFloor.GroundFloor)
        {
            transform.position = groundFloor.position;
        }
        else if (startingFloor == StartingFloor.TopFloor)
        {
            transform.position = topFloor.position;
        }

        // Open the doors so the player can enter as soon as the game starts.  
        OpenDoors();
    }

    public enum StartingFloor
    {
        GroundFloor,
        TopFloor
    }

    // This method makes this script only work with two floors. 
    // Should be triggered by player entering collision zone. 
    public async void MoveBetweenFloors()
    {
        // If we are on the ground floor, go to the top floor. 
        if (isAtFloor(groundFloor))
        {
            targetFloor = topFloor;
        }
        // Otherwise if we are on the top floor, go to the ground floor. 
        else if (isAtFloor(topFloor))
        {
            targetFloor = groundFloor;
        }
        // Move elevator 
        await transform.DOMove(targetFloor.position, travelDuration).AsyncWaitForCompletion();
        // Open doors once elevator stops moving 
        OpenDoors();
    }

    // Return true if the elevator is at the given floor. 
    bool isAtFloor(Transform floor)
    {
        if (transform.position == floor.position)
        {
            return true;
        }
        else { return false; }
    }

    public void OpenDoors()
    {
        leftDoor.Open();
        rightDoor.Open();
    }

    public void CloseDoors(bool beforeMoving)
    {
        // Close doors
        leftDoor.Close();
        rightDoor.Close();

        // Call elevator movement when doors are closed 
        if (beforeMoving)
        {
            Invoke(nameof(MoveBetweenFloors), timeForDoorsToClose);
        }
    }
}