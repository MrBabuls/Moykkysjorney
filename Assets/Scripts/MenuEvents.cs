using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    public GameObject panel;

    private float value;

    private void Start()
    {
        mixer.GetFloat("volume", out value);
        volumeSlider.value = value;
    }

    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }

    public void LoadLevel(int index)
    {
        DontDestroyOnLoad(gameObject);
        panel.SetActive(false);
        SceneManager.LoadScene(index);
    }   

}