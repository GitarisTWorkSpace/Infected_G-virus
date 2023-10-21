using UnityEngine;

public class SpeedModel : MonoBehaviour
{
    [SerializeField] public bool isMove = false;
    [SerializeField] private float speedMove;
    [SerializeField] public bool isRun = false;
    [SerializeField] private float speedRun;
    [SerializeField] private float speedRunSmooth;
    [SerializeField] public bool isSquatDown = false;
    [SerializeField] private float speedSquatDown;
    [SerializeField] private float speed;
    [SerializeField] private float speedCurrent; // убрать сериализацию
    public float GetSpeed()
    {
        return speed;
    }

    public float GetSpeedCurrent()
    {
        return speedCurrent;
    }
    public void SetSpeed()
    {
        if (isMove)
            speed = speedMove;
        if (isMove && isRun)
            speed = speedRun;
        if (isMove && isSquatDown)
            speed = speedMove - speedSquatDown;
        if (isMove && isRun && isSquatDown)
            speed = speedRun - speedSquatDown;

        speedCurrent = speed;
    }

    public void Stop()
    {
        speed = 0;
        SetSpeed();
    }
}
