using UnityEngine;

public class EquationsButton : MonoBehaviour
{
    bool equationOn = false;
    public GameObject equationisImg;
    public MeshCollider milikan;
    public Collider vtgBox, oilBomb, timer1, timer2;

    public void EnableEquationsButton()
    {
        if(!equationOn)
        {
            equationOn = true;

            equationisImg.SetActive(true);

            vtgBox.enabled = false;
            milikan.enabled = false;
            oilBomb.enabled = false;
            timer1.enabled = false;
            timer2.enabled = false;
        }
        else if(equationOn)
        {
            equationOn = false;

            equationisImg.SetActive(false);

            vtgBox.enabled = true;
            milikan.enabled = true;
            oilBomb.enabled = true;
            timer1.enabled = true;
            timer2.enabled = true;
        }
    }
}
