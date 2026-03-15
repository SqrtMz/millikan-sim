using UnityEngine;

public class OilDropBombing : MonoBehaviour
{
    public OilDrop oilDrop;
    public AudioSource sound;

    public void OnMouseDown()
    {
        int length = Random.Range(1, 11);

        for(int i = 0; i < length; i++)
        {
            float rndRad = Random.Range(1f, 2f);

            oilDrop = new OilDrop(rndRad);
        }

        sound.Play();
    }
}