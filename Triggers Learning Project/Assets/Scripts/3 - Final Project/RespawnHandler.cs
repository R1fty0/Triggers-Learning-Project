using UnityEngine;

public class RespawnHandler : MonoBehaviour, ITriggerable
{
    public Transform player;
    public Transform spawnPosition;
    public DeathText deathText;

    public void TriggerEntered()
    {
        print("Player died!");
        player.position = spawnPosition.position;
        deathText.StartFade();
    }

    public void TriggerExited() 
    {
        print("Player respawned!");
    }
}
