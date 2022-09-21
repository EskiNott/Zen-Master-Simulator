using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    private bool Enable;
    public float UIMovingSpeed = 10.0f;
    public float UIChangeSpeed = 4.0f;

    public bool SidebarEnabled;
    public bool MenuEnabled;

    [SerializeField] Transform SidebarOpened;
    [SerializeField] Transform SidebarClosed;
    [SerializeField] Transform Sidebar;
    [SerializeField] CanvasGroup StartMenuCanvasGroup;

    private void Start()
    {
        MenuEnabled = true;
    }

    void Update()
    {
        StartMenuChange();
        SidebarMoving();
        EnableSituationManage();
    }

    public bool GetUISituation()
    {
        return Enable;
    }

    private void EnableSituationManage()
    {
        Enable = SidebarEnabled || MenuEnabled;
    }

    private void StartMenuChange()
    {
        if (StartMenuCanvasGroup.gameObject.activeSelf)
        {
            StartMenuCanvasGroup.alpha = MenuEnabled ?
                Mathf.Lerp(StartMenuCanvasGroup.alpha, 1, Time.deltaTime * UIChangeSpeed) :
                Mathf.Lerp(StartMenuCanvasGroup.alpha, 0, Time.deltaTime * UIChangeSpeed);
            if(StartMenuCanvasGroup.alpha <= 0.05)
            {
                StartMenuCanvasGroup.gameObject.SetActive(false);
            }
        }
    }

    private void SidebarMoving()
    {
        Sidebar.position = SidebarEnabled ?
            Vector3.Lerp(Sidebar.position, SidebarOpened.position, Time.deltaTime * UIMovingSpeed) :
            Vector3.Lerp(Sidebar.position, SidebarClosed.position, Time.deltaTime * UIMovingSpeed);
    }
}
