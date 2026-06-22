using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHoldButtonRight : MonoBehaviour,
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
            player.MoveRight();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.StopMoving();
    }

 public void OnPointerEnter(PointerEventData eventData)
{
    if (eventData.pointerPress != null)
    {
        player.MoveRight(); 
    }
}

public void OnPointerExit(PointerEventData eventData)
{
    player.StopMoving();
}
}