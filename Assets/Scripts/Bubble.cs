using System.Collections;
using TMPro;
using UnityEngine;



class Phrase
{
    private float dtime;
    Transform actor;
    string actorName;
    string text;
    float duration;

    public Phrase(float dtime, Transform actor, string actorName, string text, float duration)
    {
        this.dtime = dtime;
        this.actor = actor;
        this.actorName = actorName;
        this.text = text;
        this.duration = duration;
    }

    public float Dtime { get => dtime; set => dtime = value; }
    public Transform Actor { get => actor; set => actor = value; }
    public string ActorName { get => actorName; set => actorName = value; }
    public string Text { get => text; set => text = value; }
    public float Duration { get => duration; set => duration = value; }
}

class Bubble : MonoBehaviour
{
    Transform TargetTransform;
    public TextMeshProUGUI text;
    public Canvas canvas;
    
    private void FixedUpdate()
    {
        if (TargetTransform == null)
            return;
        // this.transform.position = TargetTransform.position;

        //this is the ui element
        RectTransform UI_Element=GetComponent<RectTransform>();
        // UI_Element.SetPositionAndRotation(TargetTransform.position, Quaternion.identity);
        UI_Element.anchoredPosition = TargetTransform.position;

        // //first you need the RectTransform component of your canvas
        // RectTransform CanvasRect=canvas.GetComponent<RectTransform>();

        // //then you calculate the position of the UI element
        // //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.

        // Vector2 ViewportPosition=Camera.main.WorldToViewportPoint(TargetTransform.position);
        // Vector2 WorldObject_ScreenPosition=new Vector2(
        // ((ViewportPosition.x*CanvasRect.sizeDelta.x)-(CanvasRect.sizeDelta.x*0.5f)),
        // ((ViewportPosition.y*CanvasRect.sizeDelta.y)-(CanvasRect.sizeDelta.y*0.5f)));

        // //now you can set the position of the ui element
        // UI_Element.anchoredPosition=TargetTransform.position + new Vector3(UI_Element.anchorMin.x, UI_Element.anchorMin.y, 0);
        // Debug.Log(UI_Element.pivot * new Vector2(UI_Element.rect.width, UI_Element.rect.height));
    }

    public void Show(Transform transform, string text, float duration)
    {
        TargetTransform = transform;
        this.text.text = text;
        gameObject.SetActive(true);
        StartCoroutine(HideAfter(duration));
    }

    IEnumerator HideAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
