using UnityEngine;

public class SpeedModel : MonoBehaviour
{
    [SerializeField] private float speed;

    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void Stop()
    {
        speed = 0;
    }
}
