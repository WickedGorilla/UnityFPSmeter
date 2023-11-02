using TMPro;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    [RequireComponent(typeof(TextMeshPro))]
    public class FPSCounter : MonoBehaviour
    {
        private const float fpsMeasurePeriod = 0.5f;
        private const string display = "{0} FPS";
        
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        private TMP_Text m_Text;

        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_Text = GetComponent<TMP_Text>();
        }


        private void Update()
        {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                m_Text.text = string.Format(display, m_CurrentFps);
            }
        }
    }
}
