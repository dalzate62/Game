using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerMenu : MonoBehaviour
{
    public GameObject PlayerMenu;

    private bool isActive;

    private void Start()
    {
        isActive = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!isActive)
            {
                PlayerMenu.SetActive(true);
                isActive = true;
                Time.timeScale = 0f;
            }
            else
            {
                PlayerMenu.SetActive(false);
                isActive = false;
                Time.timeScale = 1f;
            }
        }
    }
}
