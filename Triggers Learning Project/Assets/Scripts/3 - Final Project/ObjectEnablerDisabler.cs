using UnityEngine;

public class ObjectEnablerDisabler : MonoBehaviour, ITriggerable
{
    public GameObject _object;
    public bool inActiveOnExit;
    public bool inActiveOnStart;

    public void Start()
    {
        // Hide the object at the beginning of the game
        if (inActiveOnStart)
        {
            _object.SetActive(false);
        }
    }

    // Show the object 
    public void TriggerEntered()
    {
        _object.SetActive(true);
    }

    // Hide the object 
    public void TriggerExited()
    {
        if (inActiveOnExit)
        {
            _object.SetActive(false);
        }
    }
}
