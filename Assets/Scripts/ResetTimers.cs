using UnityEngine;

public class ResetTimers : MonoBehaviour
{
    public VoltageTimeController vTC;

    private void OnMouseDown()
    {
        if(gameObject.name == "Circle1")
        {
            vTC.timer1.text = "0.00";
            vTC.timeVal1 = 0.00f;
            vTC.timer1Deb.text = "Time 2: " + vTC.timer1.text;
        }
        else if(gameObject.name == "Circle2")
        {
            vTC.timer2.text = "0.00";
            vTC.timeVal2 = 0.00f;
            vTC.timer2Deb.text = "Time 1: " + vTC.timer2.text;
        }
    }
}