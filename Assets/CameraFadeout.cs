using UnityEngine;
using UnityEngine.UI;

class CameraFadeout : MonoBehaviour
{
    public static CameraFadeout Instance { get; private set; }
    public Image BlackScreen;

    private void Awake()
    {
        Instance = this;
        BlackScreen.canvasRenderer.SetAlpha(0);
        BlackScreen.enabled = true;
    }

    public void InstantBlackScreen()
    {
        BlackScreen.canvasRenderer.SetAlpha(1);
    }

    public void FadeOutOfBlack(float duration = 1f) => BlackScreen.CrossFadeAlpha(0, duration, false);
}