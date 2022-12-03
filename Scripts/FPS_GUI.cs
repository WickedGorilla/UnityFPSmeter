using UnityEngine;

namespace WickedGorilla.FPS_Meter
{
    public class FPS_GUI : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 0.5f)] private float _scaleFactor = 0.15f;
        [SerializeField] private Color _colorText = Color.yellow;

        private Rect _position;
        private GUIStyle _guiStyle;
        private float _nextTimeUpdateLabel;
        private int _currentFps;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void OnGUI()
        {
            var scale = new Vector2(_scaleFactor * Screen.width, Screen.height * _scaleFactor);

            _position = new Rect(Vector2.zero, scale);
            _guiStyle = new GUIStyle
            {
                normal = { textColor = _colorText },
                fontSize = (int)(_scaleFactor * scale.x),
                alignment = TextAnchor.UpperLeft
            };

            if (Time.unscaledTime >= _nextTimeUpdateLabel)
            {
                _currentFps = (int)(1f / Time.deltaTime);
                _nextTimeUpdateLabel = Time.unscaledTime + 0.5f;
            }

            RenderValue(_currentFps);
        }

        private void RenderValue(int fps)
            => GUI.TextArea(_position, $"FPS: {fps}", _guiStyle);
    }
}