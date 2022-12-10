using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * <summary> Script to describe a menu that consumes all the users focus but does not hide previous menus </summary>
 */
public class OkModalMenu : Menu
{
    /**
     * <summary> Delegate type to define which functions that can be used as callbacks when the 'Ok' button is pressed </summary>
     */
    public delegate void OnSubmit();

    [SerializeField]
    private OnSubmit m_onSubmitCallback = null;

    [SerializeField]
    private Text m_titleText, m_contentText;

    /**
     * <summary> Called when the 'Ok' button on the modal is pressed </summary> 
     * Closes the menu and calls the callback function if specified
     */
    public void OnOkButton()
    {
        MenuManager.GetInstance().PopMenu();

        if(m_onSubmitCallback != null)
        {
            m_onSubmitCallback();
        }
    }

    /**
     * <summary> Sets the title text of the modal </summary>
     * <param name="title"> The text to be shown at the top of the modal </param>
     */
    public void SetTitle(string title)
    {
        m_titleText.text = title;
    }

    /**
     * <summary> Sets the content text of the modal </summary>
     * <param name="content"> The text to be shown in the center of the modal </param>
     */
    public void SetContent(string content)
    {
        m_contentText.text = content;
    }

    /**
     * <summary> Sets the function callback for when the 'Ok' button is pressed </summary>
     * <param name="onSubmit"> The function that should be called when the 'Ok' button is pressed </param>
     */
    public void SetOnSubmitCallback(OnSubmit onSubmit)
    {
        m_onSubmitCallback = onSubmit;
    }
    
    /**
     * <summary> Constructor for OkModalMenu, set some menu specified variables. </summary>
     */ 
    public OkModalMenu()
    {
        m_isModal = true;
        m_shouldRegister = false;
    }
}
