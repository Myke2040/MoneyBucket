using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu, LevelSelection, LoadingMenu;
    public Slider _slider;
    public Image Bar;
    // Start is called before the first frame update

    void Start()
    {
        MainMenu.SetActive(true);
        LevelSelection.SetActive(false);
        LoadingMenu.SetActive(false);
    }

    public void OnClickPlayBtn()
    {
        MainMenu.SetActive(false);
        LevelSelection.SetActive(true);
    }

    public void LoadScene(int idx)
    {
        StartCoroutine(LoadSceneCor(idx));
        LoadingMenu.SetActive(true);

    }

    IEnumerator LoadSceneCor(int Idx)
    {
        AsyncOperation _async = SceneManager.LoadSceneAsync(Idx);

        while (!_async.isDone)
        {
            Debug.Log(_async.progress);
            // _slider.value = _async.progress;
            Bar.fillAmount = _async.progress;
            yield return null;
        }
    }
}
