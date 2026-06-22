using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHoldButtonLeft : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    void Start()
    {
    }
    [SerializeField]private PlayerMovement player;

    private bool pointerInside;
    private bool pointerHeld;

    public void OnPointerDown(PointerEventData eventData)
    {
            player.MoveLeft();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.StopMoving();
    }

 public void OnPointerEnter(PointerEventData eventData)
{
    if (eventData.pointerPress != null)
    {
        player.MoveLeft(); 
    }
}

public void OnPointerExit(PointerEventData eventData)
{
    player.StopMoving();
}
}