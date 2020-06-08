using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;

    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _loadingPercentageBar;
    [SerializeField] private Text _loadingPercentageText;


    private void Awake() => Instance = this;

    public void LoadLevel(int index) {
        StartCoroutine(LoadSceneAsync(index));
    }

    private IEnumerator LoadSceneAsync(int index) {
        //Load scene in async for the loading screen/ loading bar
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        _loadingScreen.SetActive(true);

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            _loadingPercentageBar.value = progress;
            _loadingPercentageText.text = progress * 100f + "%";

            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        _loadingScreen.SetActive(false);
    }
}
