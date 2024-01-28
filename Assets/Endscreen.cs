using UnityEngine;

class Endscreen : MonoBehaviour
{
    public static Endscreen Instance { get; set; }
    private void Awake()
    {
        Instance = this;
        Hide();
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
