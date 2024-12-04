using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject creditsUI;

    [SerializeField] private Slider audioSlider;

    [SerializeField] private string [] sceneNames;

    private string volumeParamter = "MasterVolume";

    private void Start () {
        mainMenuUI.SetActive (true);
        settingsUI.SetActive (false);
        creditsUI.SetActive (false);
    }
    public void LoadPlayer () {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists (path)) {
            PlayerData data = SaveSystem.LoadPlayer ();
            SceneManager.LoadScene (data.scene);
        } else {
            SaveSystem.SavePlayer (0);
            SceneManager.LoadScene(0);
        }
    }

    public void GoToSettingsPage () {
        mainMenuUI.SetActive (false);
        settingsUI.SetActive (true);
        creditsUI.SetActive (false);
    }

    public void GoToCreditsPage () {
        mainMenuUI.SetActive (false);
        settingsUI.SetActive (false);
        creditsUI.SetActive (true);
    }

    public void GoBackToMainMenu () {
        mainMenuUI.SetActive (true);
        settingsUI.SetActive (false);
        creditsUI.SetActive (false);
    }

    public void ChangeVolume () {
        AudioListener.volume = audioSlider.value;
    }

}
