using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public ElevatorController elevatorController;
    public Transform player; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Player entered elevator");
            elevatorController.CloseDoors(true);
            player.parent = transform;
        }
    }
}
