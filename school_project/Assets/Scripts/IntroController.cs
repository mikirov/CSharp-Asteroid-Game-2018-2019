using System.Collections;

using UnityEngine;

using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {


  
    public VideoClip videoClip;
    public string MenuScene = "Menu";

    private void Start()
    {
        StartCoroutine(WaitForVideo());
    }
    private IEnumerator WaitForVideo()
    {
        float videoTime = Mathf.Ceil((float)videoClip.length);
        yield return new WaitForSecondsRealtime(videoTime);
        SceneManager.LoadScene(MenuScene);

    }

}
