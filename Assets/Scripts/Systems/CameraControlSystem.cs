using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlSystem : MonoBehaviour
{
    public static CameraControlSystem Instance;

    // 각각의 카메라, 캔버스를 유니티에서 넣어줘야함
    public Camera mapCamera;
    public Camera battleCamera;
    public Camera campCamera;
    public Camera eventCamera;
    public Camera shopCamera;

    public Canvas mapCanvas;
    public Canvas battleCanvas;
    public Canvas campCanvas;
    public Canvas eventCanvas;
    public Canvas shopCanvas;

    public Camera Current;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        ChangeMap();
    }

    public void AllOff()
    {
        battleCamera.enabled = false;
        battleCanvas.enabled = false;
        mapCamera.enabled = false;
        mapCanvas.enabled = false;
        campCamera.enabled = false;
        campCanvas.enabled = false;
        eventCamera.enabled = false;
        eventCanvas.enabled = false;
        shopCamera.enabled = false;
        shopCanvas.enabled = false;
    }

    public void TargetOn(Camera tCamera, Canvas tCanvas)
    {
        tCamera.enabled = true;
        tCanvas.enabled = true;
    }

    public void ChangeBattle()
    {
        AllOff();

        Current = battleCamera;

        TargetOn(battleCamera, battleCanvas);
    }

    public void ChangeMap()
    {
        AllOff();

        Current = mapCamera;

        TargetOn(mapCamera, mapCanvas);
    }

    public void ChangeCamp()
    {
        AllOff();

        Current = campCamera;

        TargetOn(campCamera, campCanvas);
    }

    public void ChangeEvent()
    {
        AllOff();

        Current = eventCamera;

        TargetOn(eventCamera, eventCanvas);
    }

    public void ChangeShop()
    {
        AllOff();

        Current = shopCamera;

        TargetOn(shopCamera, shopCanvas);
    }
}
