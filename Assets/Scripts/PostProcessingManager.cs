using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    [Header("Volume stuff")]
    public Volume forestVolume;
    public Volume SwampVolume;
    public VolumeProfile forestVolumeProfiler;
    public VolumeProfile swampVolumeProfiler;
    private ColorAdjustments colorAdjustments;

    [Header("Stuff to keep track off")]
    public bool HueShiftchangerActive;
    [SerializeField] private float hueShiftValue;
    public float acceleration;
    public float volumeWeightAccelerator;
    
    private void Start()
    {
        SwampVolume.weight = 1f;
        forestVolume.weight = 0f;
        forestVolumeProfiler.TryGet<ColorAdjustments>(out colorAdjustments);
        hueShiftValue = colorAdjustments.hueShift.value;

        if (colorAdjustments == null)
            Debug.LogError("No ColorAdjustments found on profile");
        
    }

    private void Update()
    {
        if(colorAdjustments != null && HueShiftchangerActive)
        {
            hueShiftValue += acceleration * Time.deltaTime;

            if(hueShiftValue > 179f)
            {
                hueShiftValue = -180f;
            }

            colorAdjustments.hueShift.value = hueShiftValue;
        }
    }

    public void VolumeSwitch()
    {
        StartCoroutine(VolumeSwitcher());
    }

    public IEnumerator VolumeSwitcher()
    {
        while (forestVolume.weight < 1f)
        {
            forestVolume.weight += volumeWeightAccelerator * Time.deltaTime;
            SwampVolume.weight -= volumeWeightAccelerator * Time.deltaTime;
        }

            yield return null;
    }

    public void HueShiftActivator(bool Activate)
    {
        HueShiftchangerActive = Activate;
    }

}
