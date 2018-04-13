using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class VerticalAutoSlider : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float m_slideSpeed;

    Coroutine m_goToRoutine;
    private ScrollRect m_scrollRect;

    public RectTransform Content { get { return MyScrollRect.content; } }
    public System.Action OnValueChanged;

    public ScrollRect MyScrollRect
    {
        get
        {
            if (m_scrollRect == null) m_scrollRect = GetComponent<ScrollRect>();
            return m_scrollRect;
        }
    }


    public void ResetPosition()
    {
        MyScrollRect.normalizedPosition = new Vector2(0.5f, 1);
    }


    //Slide to target Section 
    private IEnumerator GoToRoutine(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();
        Vector2 localScrollRectPosition = (Vector2)MyScrollRect.transform.InverseTransformPoint(Content.position);
        Vector2 localNewScrollRectPosition = (Vector2)MyScrollRect.transform.InverseTransformPoint(target.position);
        Vector2 targetPosition = localScrollRectPosition - localNewScrollRectPosition;
        MyScrollRect.enabled = false;
        while ((Vector2)Content.localPosition != targetPosition)
        {
            OnValueChanged.SafeInvoke();
            Content.localPosition = Vector2.Lerp(Content.localPosition, targetPosition, m_slideSpeed);
            if (Vector2.Distance(Content.localPosition, targetPosition) < 5)
            {
                Content.localPosition = targetPosition;
                break;
            }
            yield return null;
        }
        MyScrollRect.enabled = true;
    }


    //by normalized position
    private IEnumerator GoToRoutine(float normalizedPosY)
    {
        Canvas.ForceUpdateCanvases();
        Vector2 targetNormalizedPosition = new Vector2(0, normalizedPosY);
        MyScrollRect.enabled = false;
        while (MyScrollRect.normalizedPosition != targetNormalizedPosition)
        {
            MyScrollRect.normalizedPosition = Vector2.Lerp(MyScrollRect.normalizedPosition, targetNormalizedPosition, m_slideSpeed * 0.5f);
            if (Vector2.Distance(MyScrollRect.normalizedPosition, targetNormalizedPosition) < 0.01f)
            {
                MyScrollRect.normalizedPosition = targetNormalizedPosition;
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        MyScrollRect.enabled = true;
    }


    public void GoTo(RectTransform target)
    {
        if (m_goToRoutine != null) StopCoroutine(m_goToRoutine);
        m_goToRoutine = StartCoroutine(GoToRoutine(target));
    }


    public void GoTo(float targetPos)
    {
        if (m_goToRoutine != null) StopCoroutine(m_goToRoutine);
        m_goToRoutine = StartCoroutine(GoToRoutine(targetPos));
    }


    public void GoToImmediately(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();
        Vector2 localScrollRectPosition = (Vector2)MyScrollRect.transform.InverseTransformPoint(Content.position);
        Vector2 localNewScrollRectPosition = (Vector2)MyScrollRect.transform.InverseTransformPoint(target.position);
        Vector2 targetPosition = localScrollRectPosition - localNewScrollRectPosition;
        Content.localPosition = targetPosition;
    }


    public void SetInputInteractable(bool interactable)
    {
        MyScrollRect.enabled = interactable;
    }
}
