using UnityEngine;
using TMPro;

public class CameraText : MonoBehaviour
{
    public void SetLabel(string label)
    {
        GetComponent<TMP_Text>().text = label;
    }
}
