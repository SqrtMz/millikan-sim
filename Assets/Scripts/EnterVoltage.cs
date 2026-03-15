using UnityEngine;

public class EnterVoltage : MonoBehaviour
{
    public GameObject mainCamera;
    public Vector3[] pos;
    public Quaternion[] rot;
    public GameObject backButton;
    public GameObject slider;
    private Vector3 nextPos;
    private Quaternion nextRot;
    private int index = 0;
    private bool vtgView = false;
    public EnterOil etOil;

    private void Update()
    {
        nextPos = pos[index];
        nextRot = rot[index];

        if(vtgView && Input.GetKeyDown(KeyCode.R))
        {
            backButton.SetActive(true);
            slider.SetActive(false);
            index = 0;
        }

        if(etOil.oilView)
        {
            index = 2;
        }
        
        if(etOil.oilView && Input.GetKeyDown(KeyCode.R))
        {
            index = 0;
            etOil.oilView = false;
        }

        mainCamera.transform.SetPositionAndRotation(Vector3.Lerp(mainCamera.transform.position, nextPos, 3f * Time.deltaTime),
                                                    Quaternion.Lerp(mainCamera.transform.rotation, nextRot, 3f * Time.deltaTime));
    }

    private void OnMouseDown()
    {
        vtgView = true;
        backButton.SetActive(false);
        slider.SetActive(true);
        index = 1;
    }
}