using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject eventPanelUserInRange;

    [SerializeField] private GameObject eventPanelUserNotInRange;
    private bool isUIPanelActive;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayStartEventPanel()
    {
        if (isUIPanelActive == false)
        {
            eventPanelUserInRange.SetActive(true);
            isUIPanelActive = true;
        }
        
    }

    public void DisplayUserNotInRangePanel()
    {
        if (isUIPanelActive == false)
        {
            eventPanelUserNotInRange.SetActive(true);
        }

        isUIPanelActive = true;
    }

    public void CloseButtonClick()
    {
        eventPanelUserInRange.SetActive(false);
        eventPanelUserNotInRange.SetActive(false);
        isUIPanelActive = false;
    }
}
