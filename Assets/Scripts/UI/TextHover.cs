using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class TextHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;
    public Color normalColor = Color.white;
    public Color hoverColor = Color.yellow;
    void Start()
    {
        text.color = normalColor;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = hoverColor;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = normalColor;
    }
}