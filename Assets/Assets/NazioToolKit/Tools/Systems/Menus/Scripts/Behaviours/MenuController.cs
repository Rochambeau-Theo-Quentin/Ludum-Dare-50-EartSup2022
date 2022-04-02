using System.Collections;
using UnityEngine;
using TMPro;

namespace NazioToolKit
{
    public class MenuController : MonoBehaviour
    {
        public enum Panel
        {
            Main = 0,
            Option = 1,
            Credits = 2,
        }

        [SerializeField] private NUIPanel[] panels;
        [SerializeField] private TextMeshProUGUI title;
        private OptionController option;
        private CreditsController credit;

        private bool mustUpdatePanels;

        [Header("Pause")]
        [SerializeField] private bool isPauseMenu;
        [SerializeField] private bool stopTime;
        private bool isEnabled;

        #region UnityMethods

        private void Awake()
        {
            option = GetComponentInChildren<OptionController>();
            credit = GetComponentInChildren<CreditsController>();
        }

        private void Start()
        {
            if(!isPauseMenu) ChangeCurrentPanel(panels[(int)Panel.Main]);
            if(isPauseMenu) ChangeCurrentPanel(null);
            UpdateDisplay();
        }

        private void Update()
        {
            if (mustUpdatePanels) UpdateDisplay();
        }

        #endregion

        #region Inputs

        public void ChangeState()
        {
            if(!isPauseMenu) return;

            isEnabled = !isEnabled;

            if (isEnabled)
            {
                if (stopTime) Time.timeScale = 0f;

                ChangeCurrentPanel(panels[(int)Panel.Main]);
            }
            else
            {
                if (stopTime) Time.timeScale = 1f;
                
                ChangeCurrentPanel(null);
            }

            mustUpdatePanels = true;
        }

        public void ChangeScene(string _sceneName)
        {
            GameManager.ChangeScene(_sceneName);
        }

        public void Options()
        {
            NUIPanel _panel = panels[(int)Panel.Option];
            if (!_panel.isActive)
            {
                ChangeCurrentPanel(_panel);
                option.Active();
                return;
            }

            ChangeCurrentPanel(panels[(int)Panel.Main]);
        }

        public void Credits(bool _active)
        {
            if (!_active) //Desactive
            {
                ChangeCurrentPanel(panels[(int)Panel.Main]);
                StartCoroutine(TitleAnimation(1, 0, 0.5f));
                return;
            }

            credit.Launch();
            StartCoroutine(TitleAnimation(-1, 0.5f, 0));
            ChangeCurrentPanel(panels[(int)Panel.Credits]);
        }

        public void Quit()
        {
            GameManager.Quit();
        }

        #endregion

        private void ChangeCurrentPanel(NUIPanel _OpenedPanel)
        {
            foreach (var _panel in panels)
            {
                _panel.Desactive();
            }

            mustUpdatePanels = true;
            if (_OpenedPanel == null) return;

            _OpenedPanel.Active();
        }

        private void UpdateDisplay()
        {
            int inTransitionNB = 0;
            foreach (var _panel in panels)
            {
                if (_panel.inTransition == true) inTransitionNB++;
            }

            if (inTransitionNB == 0)
            {
                mustUpdatePanels = false;
                return;
            }

            foreach (var _panel in panels)
            {
                _panel.UpdatePanels();
            }
        }

        private IEnumerator TitleAnimation(int _multiplicator, float _startValue, float _targetValue)
        {
            float _t = _startValue;
            while (true)
            {
                yield return null;
                _t += Time.deltaTime * _multiplicator;

                title.color = new Color(title.color.r, title.color.g, title.color.b, _t / _targetValue);

                if (_multiplicator > 1 && _t > _targetValue) break;
                if (_multiplicator < 1 && _t < _targetValue) break;
            }
        }
    }
}

