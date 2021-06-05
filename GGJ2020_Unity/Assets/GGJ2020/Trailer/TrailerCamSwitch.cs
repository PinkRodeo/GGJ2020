using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerCamSwitch : MonoBehaviour
{
    public GameObject GameCam;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    public GameObject cam6;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("GameCamera"))
        {
          GameCam.SetActive(true);
          cam2.SetActive(false);
          cam3.SetActive(false);
          cam4.SetActive(false);
          cam5.SetActive(false);
          cam6.SetActive(false);
        }

        if (Input.GetButtonDown("TrailerCam2"))
        {
          GameCam.SetActive(false);
          cam2.SetActive(true);
          cam3.SetActive(false);
          cam4.SetActive(false);
          cam5.SetActive(false);
          cam6.SetActive(false);
        }

        if (Input.GetButtonDown("TrailerCam3"))
        {
          GameCam.SetActive(false);
          cam2.SetActive(false);
          cam3.SetActive(true);
          cam4.SetActive(false);
          cam5.SetActive(false);
          cam6.SetActive(false);
        }

        if (Input.GetButtonDown("TrailerCam4"))
        {
          GameCam.SetActive(false);
          cam2.SetActive(false);
          cam3.SetActive(false);
          cam4.SetActive(true);
          cam5.SetActive(false);
          cam6.SetActive(false);
        }

        if (Input.GetButtonDown("TrailerCam5"))
        {
          GameCam.SetActive(false);
          cam2.SetActive(false);
          cam3.SetActive(false);
          cam4.SetActive(false);
          cam5.SetActive(true);
          cam6.SetActive(false);
        }

        if (Input.GetButtonDown("TrailerCam6"))
        {
          GameCam.SetActive(false);
          cam2.SetActive(false);
          cam3.SetActive(false);
          cam4.SetActive(false);
          cam5.SetActive(false);
          cam6.SetActive(true);
        }
    }
}
