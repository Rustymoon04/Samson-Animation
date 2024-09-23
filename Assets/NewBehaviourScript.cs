using UnityEngine;
using DG.Tweening;

public class CardAnimation : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isClicked = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        if (!isClicked)
        {
            transform.DOScale(originalScale * 1.2f, 0.3f);
        }
    }

    void OnMouseExit()
    {
        if (!isClicked)
        {
            transform.DOScale(originalScale, 0.3f);
        }
    }

    void OnMouseDown()
    {
        if (!isClicked)
        {
            isClicked = true;

            // Create a DOTween sequence
            Sequence cardSequence = DOTween.Sequence();

            // Rotate the card
            cardSequence.Append(transform.DORotate(new Vector3(0, 180, 0), 0.5f, RotateMode.FastBeyond360));

            // Shake the card after the rotation
            cardSequence.Append(transform.DOShakeRotation(0.5f, new Vector3(0, 10, 0), 10, 90));

            // Return to original scale after the shake
            cardSequence.Append(transform.DOScale(originalScale, 0.3f));
        }
    }
}
