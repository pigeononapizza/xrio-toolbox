using System.Collections;
using System.Collections.Generic;

public class GetTriggerEvents : DebugBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DebugMessage($"{other.name} entered the trigger on {gameObject.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        DebugMessage($"{other.name} exited the trigger on {gameObject.name}");
    }
}