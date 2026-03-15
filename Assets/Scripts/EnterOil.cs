using UnityEngine;

public class EnterOil : MonoBehaviour
{
    public GameObject mainCamera, oilViewCamera, overlay, backButton, bombButton, slider;
    public bool oilView = false;

    private void Update()
    {
        if(oilView && Input.GetKeyDown(KeyCode.R))
        {
            mainCamera.SetActive(true);
            oilViewCamera.SetActive(false);
            overlay.SetActive(false);
            backButton.SetActive(true);
            bombButton.SetActive(false);
            slider.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        oilView = true;
        mainCamera.SetActive(false);
        oilViewCamera.SetActive(true);
        overlay.SetActive(true);
        backButton.SetActive(false);
        bombButton.SetActive(true);
        slider.SetActive(true);
    }
}