using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ToogleSwitch : MonoBehaviour
{
    public Transform onPos;
    public Transform OffPos;
    public GameObject switchObject;
    public float AnimTime;
    [ColorUsage(true, true)] public Color ActivatedColor;
    [ColorUsage(true, true)] public Color DeActivatedColor;

    private bool activated;
    private AbstractSwitch button;
    private Renderer switchRenderer;

    public void Awake()
    {
        activated = true;
        button = GetComponent<AbstractSwitch>();
        switchRenderer = switchObject.GetComponent<Renderer>();
        switchRenderer.material.color = ActivatedColor;
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ToggleSwitch();
        }
    }


    public void ToggleSwitch()
    {
        activated = !activated;

        if (activated)
        {
            switchObject.transform.DOMove(onPos.position, AnimTime).SetEase(Ease.OutQuart);
            switchRenderer.material.color = ActivatedColor;
            if (button)
            {
                button.ActivateSwitch();
            }
            else
            {
                print("no hay boton que activar");
            }
        }
        else
        {
            switchObject.transform.DOMove(OffPos.position, AnimTime).SetEase(Ease.OutQuart);
            switchRenderer.material.color = DeActivatedColor;
            if (button)
            {
                button.DeActivateSwitch();
            }
            else
            {
                print("no hay boton que desactivar");
            }
        }
    }
}
