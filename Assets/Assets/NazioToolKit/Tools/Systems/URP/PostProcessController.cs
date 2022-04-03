using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

namespace NazioToolKit
{
    public class PostProcessController : MonoBehaviour
    {
        private Volume volume;

        private ChromaticAberration aberration;
        private Vignette vignette;
        private float baseIntensity;

        private void Awake()
        {
            volume = GetComponent<Volume>();

            volume.profile.TryGet(out vignette);
            volume.profile.TryGet(out aberration);

            baseIntensity = vignette.intensity.value;
            aberration.intensity.value = 0;
        }

        public void ModifyVignette(float _intensity)
        {
            vignette.intensity.value = baseIntensity + _intensity;
        }

        public void SetAberrationValue(float _value)
        {
            aberration.intensity.value = _value;
        }

        public void ResetVignette()
        {
            vignette.intensity.value = baseIntensity;
        }
    }
}