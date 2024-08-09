using UnityEngine;

public class BreathingArea : MonoBehaviour
{
    public float distance;
    public GameObject player;
    public bool inSafeArea;
    void Update()
    {
        distance = (Vector3.Distance(transform.position, player.transform.position));
        if (distance < 15)
        {
            inSafeArea = true;
        }
        else
        {
            inSafeArea = false;

        }
    }

}
