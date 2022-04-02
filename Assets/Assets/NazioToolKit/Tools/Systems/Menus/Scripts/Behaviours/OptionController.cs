using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System.Linq;

namespace NazioToolKit
{
    [System.Serializable]
    public class AudioSliderController
    {
        [SerializeField] private string channelName;
        [SerializeField] private Slider slider;

        public void SetMixerValue(AudioMixer _mixer)
        {
            _mixer.SetFloat(channelName, slider.value);
        }

        public void SetSliderValue(AudioMixer _mixer)
        {
            float _value;
            _mixer.GetFloat(channelName, out _value);
            slider.value = _value;
        }
    }

    [System.Serializable]
    public class ButtonCanvasController
    {
        public string name;
        [SerializeField] private Canvas canvas;
        [SerializeField] private Button button;

        private Image buttImage;
        private TextMeshProUGUI buttText;

        private Color desactivatedColor = new Color(0.8f, 0.8f, 0.8f, 1f);
        private Color activatedColor = new Color(0.3f, 0.3f, 0.3f, 1f);

        public void Active()
        {
            canvas.enabled = true;
            buttImage.color = activatedColor;
            buttText.color = desactivatedColor;
        }

        public void Desactive()
        {
            canvas.enabled = false;
            buttImage.color = desactivatedColor;
            buttText.color = activatedColor;
        }

        public void Init(Color _desactivatedColor, Color _activatedColor)
        {
            buttImage = button.GetComponent<Image>();
            buttText = button.GetComponentInChildren<TextMeshProUGUI>();

            desactivatedColor = _desactivatedColor;
            activatedColor = _activatedColor;
        }
    }

    public class OptionController : MonoBehaviour
    {
        [SerializeField] private MenuController mainMenu;

        [Header("Audio")]
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private AudioSliderController[] audioControllers;


        [Header("Catégories")]
        [SerializeField] private ButtonCanvasController[] optionsPanels;
        [SerializeField] private Color desactivatedColor = new Color(0.8f, 0.8f, 0.8f, 1f);
        [SerializeField] private Color activatedColor = new Color(0.3f, 0.3f, 0.3f, 1f);

        [Header("Resolution")]
        [SerializeField] private TMP_Dropdown resolutionDropDown;
        private Resolution[] resolutions;

        private void Start()
        {
            foreach (var _controller in audioControllers)
            {
                _controller.SetSliderValue(mixer);
            }
            foreach (var _controller in optionsPanels)
            {
                _controller.Init(desactivatedColor, activatedColor);
            }

            InitResolutions();
        }

        private void InitResolutions()
        {
            resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
            resolutionDropDown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                if (options.Contains(option) == false)
                {
                    options.Add(option);
                }
                if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropDown.AddOptions(options);
            resolutionDropDown.value = currentResolutionIndex;
            resolutionDropDown.RefreshShownValue();
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void UpdateMixerValues()
        {
            foreach (var _controller in audioControllers)
            {
                _controller.SetMixerValue(mixer);
            }
        }

        public void SetFullScreen(bool _fullScreen)
        {
            Screen.fullScreen = _fullScreen;
        }

        public void SetCategorie(int _categoryID)
        {
            foreach (var _panels in optionsPanels)
            {
                _panels.Desactive();
            }

            optionsPanels[_categoryID].Active();
        }

        public void Active()
        {
            SetCategorie(0);
        }
    }
}