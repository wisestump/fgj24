using System.Collections.Generic;
using System.Collections;
using UnityEngine;

class DialogRunner : MonoBehaviour
{
    public Phrases Phrases;
    public Bubble bubble;
    public Bubble clawBubble;

    public void ShowDialogsFor(string zone)
    {
        var zoneP = Phrases.Parse()[zone];
        StartCoroutine(ShowDialogsRoutine(zoneP));
    }

    IEnumerator ShowDialogsRoutine(List<Phrase> phrases)
    {
        float mult = 3;
        float previousTime = 0f;
        for(int i = 0; i < phrases.Count; ++i)
        {
            var phrase = phrases[i];
            var currentBubble = phrase.ActorName == "claw" ? clawBubble : bubble;
            yield return new WaitForSeconds(mult*(phrase.Dtime - previousTime));
            currentBubble.Show(phrase.Actor, phrase.Text, mult*phrase.Duration);
            previousTime = phrase.Dtime;
        }
    }
}
