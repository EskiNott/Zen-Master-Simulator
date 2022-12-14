using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoSingleton<UIManager>
{
    private bool Enable;
    public float UIMovingSpeed = 10.0f;
    public float UIChangeSpeed = 4.0f;

    public bool SidebarEnabled;
    public bool MenuEnabled;

    private bool StartClicked = false;

    private List<RaycastResult> RayResult;

    [SerializeField] Transform Canvas2D;
    [SerializeField] Transform Sidebar;
    [SerializeField] CanvasGroup SidebarCanvasGroup;
    [SerializeField] CanvasGroup StartMenuCanvasGroup;
    [SerializeField] CanvasGroup MeritCountUI;
    [SerializeField] TextMeshProUGUI MeritCountText;
    [SerializeField] Transform ContentTrans;

    private void Start()
    {
        MenuEnabled = true;
        RayResult = new();
    }

    void Update()
    {
        StartMenuChange();
        MeritCountUIChange();
        SidebarEnabledControl();
        SidebarChange();
/*        SidebarMoving();*/
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
                Mathf.Lerp(StartMenuCanvasGroup.alpha, 1, Time.deltaTime * UIChangeSpeed * 1 / 4) :
                Mathf.Lerp(StartMenuCanvasGroup.alpha, 0, Time.deltaTime * UIChangeSpeed * 1 / 4);
            if (StartMenuCanvasGroup.alpha <= 0.02 && StartClicked)
            {
                StartMenuCanvasGroup.gameObject.SetActive(false);
            }
        }
    }

    public void StartClick()
    {
        StartClicked = true;
    }

    public void SetMeritCountUIText(float count)
    {
        MeritCountText.text = count.ToString();
    }

    private void MeritCountUIChange()
    {
        if(MeritCountUI.alpha >= 0.995)
        {
            return;
        }
        MeritCountUI.alpha = MenuEnabled ?
            Mathf.Lerp(MeritCountUI.alpha, 0, Time.deltaTime * UIChangeSpeed * 1 / 4) :
            Mathf.Lerp(MeritCountUI.alpha, 1, Time.deltaTime * UIChangeSpeed * 1 / 4);
    }

/*    private void SidebarMoving()
    {
        Sidebar.position = SidebarEnabled ?
            Vector3.Lerp(Sidebar.position, SidebarOpened.position, Time.deltaTime * UIMovingSpeed) :
            Vector3.Lerp(Sidebar.position, SidebarClosed.position, Time.deltaTime * UIMovingSpeed);
    }*/
    
    private void SidebarEnabledControl()
    {
        if (EventSystem.current.IsPointerOverGameObject() && !MenuEnabled)
        {
            EventSystem.current.RaycastAll(new PointerEventData(EventSystem.current) { position = Input.mousePosition }, RayResult);
            if (RayResult.Count > 0)
            {
                /*                bool result = false;
                                GameObject GoPointerAt = RayResult[0].gameObject;
                                GameObject GoPointerAtParent = GoPointerAt.transform.parent.gameObject;
                                if (GoPointerAtParent.name == "Sidebar")
                                {
                                    result = true;
                                }
                                else
                                {
                                    foreach(Transform i in ContentTrans)
                                    {
                                        if(GoPointerAt == i.gameObject)
                                        {
                                            result = true;
                                            break;
                                        }
                                    }
                                }
                                SidebarEnabled = result;*/
                Debug.Log(RayResult[0].gameObject.name);
                SidebarEnabled = GameManager.IsChildHasParent(RayResult[0].gameObject.transform, Canvas2D, Sidebar);
            }
        }
        else
        {
            SidebarEnabled = false;
        }
    }

    private void SidebarChange()
    {
        SidebarCanvasGroup.alpha = SidebarEnabled?
            Mathf.Lerp(SidebarCanvasGroup.alpha, 1, Time.deltaTime * UIChangeSpeed * 2) :
            Mathf.Lerp(SidebarCanvasGroup.alpha, 0, Time.deltaTime * UIChangeSpeed * 2);
        if(SidebarCanvasGroup.alpha <= 0.02)
        {
            SidebarCanvasGroup.alpha = 0;
        }else if(SidebarCanvasGroup.alpha >= 0.98)
        {
            SidebarCanvasGroup.alpha = 1;
        }
        SetItemUIRaycast(ContentTrans, SidebarEnabled);
    }

    private void SetItemUIRaycast(Transform Parent,bool situation)
    {
        foreach(Transform trans in Parent)
        {
            trans.GetComponent<UnityEngine.UI.Image>().raycastTarget = situation;
        }
    }
}
