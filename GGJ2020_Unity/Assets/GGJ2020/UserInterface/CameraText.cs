using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraText : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRoom(int num)
    {
        if (num == 1)
            GetComponent<TMP_Text>().text = "CAM1 (LIVING)";
        if (num == 2)
            GetComponent<TMP_Text>().text = "CAM2 (BEDROOM)";
        if (num == 3)
            GetComponent<TMP_Text>().text = "CAM3 (BATHROOM)";
    }
}
