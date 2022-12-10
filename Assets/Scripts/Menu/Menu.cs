using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary> Holds information about a menu and accepts callbacks for opening and closing the menu </summary>
 */
public class Menu : MonoBehaviour
{
    /**
     * <summary> Name of the menu </summary>
     * Used as an identifier for the menu when register to the menu manager. 
     */
    [SerializeField]
    private string m_name = "";

    protected bool m_shouldRegister = true;
    protected bool m_isModal = false;

    [SerializeField]
    private GameObject m_defaultSelectable = null;

    /**
     * <summary> Menu name getter </summary>
     */
    public string GetName()
    {
        return m_name;
    }

    public GameObject GetDefaultSelectable()
    {
        return m_defaultSelectable;
    }

    public bool IsModal()
    {
        return m_isModal;
    }

    public virtual void Start()
    {
        if(m_shouldRegister)
        {
            // Register self with menu manager
            MenuManager.GetInstance().AttachMenu(this);
        }
    }

    /**
     * <summary> Menu open callback </summary>
     * Called when the menu manager opens this menu
     */
    public virtual void OnMenuOpen()
    {
        //Debug.Log("Menu: " + m_name + " opened");
    }

    /**
     * <summary> Menu close callback </summary>
     * Called when the menu manager closes this menu
     */
    public virtual void OnMenuClose()
    {
        //Debug.Log("Menu: " + m_name + " closed");
    }
}