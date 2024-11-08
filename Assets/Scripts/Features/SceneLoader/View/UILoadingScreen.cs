using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Features.SceneLoader
{
    public class UILoadingScreen : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;

        public void SetProgress(float taskProgress)
        {
            if (_progressBar == null) return;

            var progress = taskProgress / 1;
            _progressBar.fillAmount = progress;
        }
    }
}