using UnityEngine;

public class BreathingArea : MonoBehaviour
{
    public float distance;
    private GameManager gamemanger;
    public GameObject player;
    public bool inSafeArea;
    public bool hasWentDown = false;
    void Update()
    {
        distance = (Vector3.Distance(transform.position, player.transform.position));
        if (distance < 15)
        {
            inSafeArea = true;
            if (hasWentDown == true)
            {
                hasWentDown = false;
            }
        }
        else
        {
            inSafeArea = false;
            if (hasWentDown == false)
            {
                hasWentDown = true;
                AudioManager.instance.PlaySFX(AudioManager.instance.goingDown);
            }
            

        }
    }

}
