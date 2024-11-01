using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Option : MonoBehaviour
{
    private PlayerController controller;

    public GameObject optionWindow;

    public ScrollBar volumeScroll;
    public ScrollBar brightnessScroll;

    void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
        controller.optionAction += Toggle;
        optionWindow.SetActive(false);
    }

    private void Toggle()
    {
        if (IsOpen()) optionWindow.SetActive(false);
        else optionWindow.SetActive(true);
    }

    private bool IsOpen()
    {
        return optionWindow.activeInHierarchy;
    }

    public void OnSave()
    {
        AudioListener.volume = volumeScroll.volumeValue;
        brightnessScroll.light.intensity = brightnessScroll.brightnessValue;
    }
}
