using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestFade());
    }

    IEnumerator TestFade()
    {
        yield return new WaitForSecondsRealtime(1);
        CameraEffects.StartFadeToBlack(() => { print("start finished"); });
        yield return new WaitForSecondsRealtime(3);

        CameraEffects.StartFadeToGame(() => { print("end finished"); });
    }
}
