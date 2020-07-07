using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;

    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _loadingPercentageBar;
    [SerializeField] private Text _loadingPercentageText;
    [SerializeField] private Animator _fadeScreen;

    private void Awake() => Instance = Instance ? Instance : this;

    public void LoadLevel(int index) {
        StartCoroutine(LoadSceneAsync(index));
    }

    private IEnumerator LoadSceneAsync(int index) {
        //Load scene in async for the loading screen/ loading bar
        _fadeScreen.SetBool(Constants._fade_Bool, true);

        yield return new WaitForSeconds(1); //Wait until the fadeout animation is done playing
        AsyncOperation operation = SceneManager.LoadSceneAsync(index); //Load in the scene
        _loadingScreen.SetActive(true); //Enable the loading screen

        //Update the loading bar
        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            _loadingPercentageBar.value = progress;
            _loadingPercentageText.text = progress * 100f + "%";

            yield return null;
        }
        yield return new WaitForSeconds(.3f); //Wait

        _fadeScreen.SetBool(Constants._fade_Bool,false); //Start the fadein animation
        CheckForAudioListeners(); //Make sure only one audio listener is active in the scene

        //Spawn the player at the last entered door position
        if (ObjectiveManager.Instance._playerCameFromObjectiveRoom) Player.Instance.SpawnAtLastEnteredDoorPosition();
        _loadingScreen.SetActive(false); //Disable the loading screen again
    }
    private void CheckForAudioListeners() {
        GameObject cam = GameObject.FindGameObjectWithTag(Constants._mainCamera);
        Player.Instance.transform.GetChild(0).GetComponent<AudioListener>().enabled = cam && cam.GetComponent<AudioListener>() ? false : true;
    }
}
