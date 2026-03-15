using UnityEngine;

public class HelpButton : MonoBehaviour
{
    bool helpOn = true;
    public GameObject controlsImg;
    public GameObject valuesExp;
    public MeshCollider milikan;
    public Collider vtgBox, oilBomb, timer1, timer2;
    
    public void EnableHelpButton()
    {
        if(!helpOn)
        {
            helpOn = true;

            controlsImg.SetActive(true);

            valuesExp.SetActive(false);

            vtgBox.enabled = false;
            milikan.enabled = false;
            oilBomb.enabled = false;
            timer1.enabled = false;
            timer2.enabled = false;
        }
        else if(helpOn)
        {
            helpOn = false;

            controlsImg.SetActive(false);

            valuesExp.SetActive(true);

            vtgBox.enabled = true;
            milikan.enabled = true;
            oilBomb.enabled = true;
            timer1.enabled = true;
            timer2.enabled = true;
        }
    }
}