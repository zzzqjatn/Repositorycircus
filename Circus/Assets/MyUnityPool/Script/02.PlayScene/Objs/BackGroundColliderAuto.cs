using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundColliderAuto : MonoBehaviour
{
    private BoxCollider2D BackGroundCollider;
    private RectTransform BackGroundRectTransform;
    void Start()
    {
        BackGroundCollider = gameObject.GetComponent<BoxCollider2D>();
        BackGroundRectTransform = gameObject.GetComponent<RectTransform>();

        BackGroundCollider.size = new Vector2(BackGroundRectTransform.sizeDelta.x, 100f);
        BackGroundCollider.offset = new Vector2(0f, (BackGroundRectTransform.sizeDelta.y * 0.5f - 50f) * (-1));
    }

    void Update()
    {

    }
}
