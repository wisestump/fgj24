using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class HollowCircleCollider : MonoBehaviour
{
    [SerializeField]
    PolygonCollider2D polygonCollider;
    [OnChangedCall("UpdateCollider")]
    [Range(0.1f, 5f)]
    public float Radius = 1;
    [OnChangedCall("UpdateCollider")]
    [Range(10, 360)]
    public uint NumPoints = 10;
    [OnChangedCall("UpdateCollider")]
    [Range(0.1f, 0.99f)]
    public float InnerRadiusRatio = 0.9f;
    
    // Start is called before the first frame update
    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();

    }

    public void UpdateCollider()
    {

        Vector2[] points = new Vector2[2*NumPoints];
        for(int i=0; i<NumPoints; ++i)
        {
            points[i] = new Vector2(Radius * Mathf.Cos(2*Mathf.PI * i/NumPoints), Radius * Mathf.Sin(2*Mathf.PI * i/NumPoints));
        }
        for(int i=0; i<NumPoints; ++i)
        {
            points[i+NumPoints] = new Vector2(InnerRadiusRatio*Radius * Mathf.Cos(2*Mathf.PI * i/NumPoints), InnerRadiusRatio*Radius * Mathf.Sin(2*Mathf.PI * i/NumPoints));
        }
        polygonCollider.SetPath(0, points);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
