using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static int volumen;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public Slider volumeSlider;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("vol"))
        {
            volumen = PlayerPrefs.GetInt("vol");
            audioSource.volume = (float)volumen / 100;
            audioSource.Play();
        }
        else
        {
            PlayerPrefs.SetInt("vol", 50);
            volumen = PlayerPrefs.GetInt("vol");
            audioSource.volume = (float)volumen / 100;
            audioSource.Play();
        }
        
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumen = PlayerPrefs.GetInt("vol");
        audioSource.volume = (float)volumen / 100;
        audioSource.Play();
    }

    public void VolumeChange()
    {
        volumen = (int) volumeSlider.value;
        PlayerPrefs.SetInt("vol", volumen);
        audioSource.volume = (float)volumen / 100;

    }
}
