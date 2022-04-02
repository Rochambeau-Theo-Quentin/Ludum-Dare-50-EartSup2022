using UnityEngine;

namespace NazioToolKit
{
    public enum TransitionType
    {
        No,
        Fade,
    }

    [System.Serializable]
    public class NUIPanel
    {
        public string name;
        [HideInInspector] public bool isActive;

        [Header("Objects")]
        [SerializeField] private CanvasGroup group;
        [SerializeField] private Canvas canvas;

        [Header("Parametters")]
        [SerializeField] private TransitionType transitionType;
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private float animTime = 1f;
        private float currentAdvancement = 0f;
        [HideInInspector] public bool inTransition;

        private const float desactiveSpeedMultiplicator = 2f;

        public void UpdatePanels()
        {
            if (!inTransition) return;

            if (isActive)
            {
                currentAdvancement += Time.unscaledDeltaTime;

                if (currentAdvancement >= animTime)
                {
                    inTransition = false;
                    currentAdvancement = animTime;
                    canvas.enabled = true;
                }

                float _t = currentAdvancement / animTime;
                group.alpha = curve.Evaluate(_t);
            }
            else
            {
                currentAdvancement -= Time.unscaledDeltaTime * desactiveSpeedMultiplicator;

                if (currentAdvancement <= 0)
                {
                    inTransition = false;
                    currentAdvancement = 0;
                    canvas.enabled = false;
                }

                float _t = currentAdvancement / animTime;
                group.alpha = curve.Evaluate(_t);
            }
        }

        public void Desactive()
        {
            isActive = false;
            inTransition = true;
            canvas.enabled = true;
        }

        public void Active()
        {
            isActive = true;
            inTransition = true;
            canvas.enabled = true;
        }
    }
}