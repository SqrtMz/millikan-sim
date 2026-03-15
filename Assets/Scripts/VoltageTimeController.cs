using TMPro;
using UnityEngine;

public class VoltageTimeController : MonoBehaviour
{
    public GameObject knob;
    public TextMeshPro timer1, timer2, vtg;
    public TextMeshProUGUI timer1Deb, timer2Deb, vtgOnDeb;
    public AudioSource audioSound;
    public float timeVal1, timeVal2 = 0f;
    private string time1, time2;
    public float voltage, knobAngle, angleBasis;
    public bool VtgOn, timerOn = false;
    public MeshRenderer light1Mat, light2Mat, light1Clock, light2Clock;

    private void Start()
    {
        angleBasis = knob.transform.eulerAngles.z;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            VtgOn = !VtgOn;
            audioSound.Play();
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            timerOn = !timerOn;
            audioSound.Play();
        }

        OnOffLgtSwt();
        Timers();

        vtgOnDeb.text = "Voltage: " + voltage.ToString();
        vtg.text = voltage.ToString();
        knobAngle = angleBasis + voltage * (276f/600f);
        // knob.transform.RotateAround(knob.transform.position,knob.transform.forward,knobAngle);
        knob.transform.eulerAngles = new Vector3(knob.transform.eulerAngles.x,knob.transform.eulerAngles.y, knobAngle);
    }

    public void Timers()
    {
        if(timerOn && !VtgOn) // Timer2 On & Voltage Off
        {
            timeVal1 += Time.deltaTime;
            time1 = timeVal1.ToString("0.00");
            timer1.text = time1;
            timer1Deb.text = "Time 2: " + time1;
        }
        else if(timerOn && VtgOn) // Timer1 On
        {
            timeVal2 += Time.deltaTime;
            time2 = timeVal2.ToString("0.00");
            timer2.text = time2;
            timer2Deb.text = "Time 1: " + time2;
        }
    }

    public void OnOffLgtSwt()
    {
        if(VtgOn)
        {
            light1Mat.material.color = Color.green;
            vtgOnDeb.color = Color.green;
        }
        else if(!VtgOn)
        {
            light1Mat.material.color = Color.red;
            vtgOnDeb.color = Color.red;
        }

        if(timerOn)
        {
            light2Mat.material.color = Color.green;
            timer1Deb.color = Color.green;
            light1Clock.material.color = Color.green;
        }
        else if(!timerOn)
        {
            light2Mat.material.color = Color.red;
            timer1Deb.color = Color.red;
            light1Clock.material.color = Color.red;
        }

        if(VtgOn && timerOn)
        {
            timer2Deb.color = Color.green;
            timer1Deb.color = Color.red;
            light2Clock.material.color = Color.green;
            light1Clock.material.color = Color.red;
        }
        else
        {
            timer2Deb.color = Color.red;
            light2Clock.material.color = Color.red;
        }
    }

    public void ChangeVoltage(float value)
    {
        voltage = value;
    }
}