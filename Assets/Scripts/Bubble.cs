using System.Collections;
using TMPro;
using UnityEngine;



class Phrase
{
    private float dtime;
    Transform actor;
    string text;
    float duration;

    public Phrase(float dtime, Transform actor, string text, float duration)
    {
        this.dtime = dtime;
        this.actor = actor;
        this.text = text;
        this.duration = duration;
    }

    public float Dtime { get => dtime; set => dtime = value; }
    public Transform Actor { get => actor; set => actor = value; }
    public string Text { get => text; set => text = value; }
    public float Duration { get => duration; set => duration = value; }
}

class Bubble : MonoBehaviour
{
    Transform TargetTransform;
    TextMeshProUGUI text;
    
    private void Update()
    {
        //this.transform.position = TargetTransform.position;
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
