using Unity.VisualScripting;
using UnityEngine;

public enum OptionType
{
    Volume,
    Brightness
}

public class ScrollBar : MonoBehaviour
{
    public Light light;

    public OptionType optionType;

    public float brightnessValue;
    public float volumeValue;

    private void Awake()
    {

    }

    public void OnScrollbarValueChanged(float value)
    {
        switch (optionType)
        {
            case OptionType.Volume:
                ChangeVolumn(value);
                break;
            case OptionType.Brightness:
                ChangeBrightness(value);
                break;
        }
    }

    public void ChangeVolumn(float value)
    {
        volumeValue = value;
    }

    public void ChangeBrightness(float value)
    {
        brightnessValue = value;
    }
}
