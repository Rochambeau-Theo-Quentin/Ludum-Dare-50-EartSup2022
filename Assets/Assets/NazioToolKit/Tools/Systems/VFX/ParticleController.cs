using UnityEngine;
using UnityEngine.VFX;

namespace NazioToolKit.Tools
{
    public class ParticleController : MonoBehaviour
    {
        private VisualEffect effect;

        [SerializeField] private Color color;

        private void Awake()
        {
            effect = GetComponent<VisualEffect>();

            effect.SetVector3("ColorVector", new Vector3(color.r, color.g, color.b));
        }
    }
}