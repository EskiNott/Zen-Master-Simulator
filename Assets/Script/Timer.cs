using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool CanStart;
    private bool FinishFlag;
    private WaitForSeconds WFS;

    public void TimerStart()
    {
        if (CanStart)
        {
            SetState(false);
            StartCoroutine(TimeDelay());
        }
    }

    public bool GetState()
    {
        return FinishFlag;
    }

    public void SetTime(float Time)
    {
        WFS = new WaitForSeconds(Time);
    }

    private void SetState(bool isStop)
    {
        CanStart = isStop;
    }

    public void TimerReset()
    {
        SetState(true);
        FinishFlag = false;
    }

    public Timer(float Time = 0.0f)
    {
        SetTime(Time);
        SetState(true);
        FinishFlag = false;
    }

    IEnumerator TimeDelay()
    {
        yield return WFS;
        SetState(true);
        FinishFlag = true;
    }

}
