using UnityEngine;

class Choice : MonoBehaviour
{
    public BoxCollider2D BoxCollider2D;
    public ChoiceAction ChoiceAction;

    private void Update()
    {
        BoxCollider2D.OverlapPoint(Player.Instance.transform.position);
        //ChoiceAction.    
    }
}
