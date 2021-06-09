using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CheckInternetConnection : MonoBehaviour
{
    [SerializeField] Text loadingText;
    [SerializeField] Text connectionErrorText;
    [SerializeField] Button tryAgainButton;
    [SerializeField] Button playButton;
      
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckInternet());
    }

    IEnumerator CheckInternet()
    {
        UnityWebRequest request = new UnityWebRequest("http://www.google.com");
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            loadingText.gameObject.SetActive(false);
            connectionErrorText.gameObject.SetActive(true);
            tryAgainButton.gameObject.SetActive(true);
        }
        else
        {
            loadingText.gameObject.SetActive(false);
            playButton.gameObject.SetActive(true);
        }
    }

    public void tryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Play(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }
}
