using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/**
 * <summary> Singleton Script to handle the stack based menus </summary>
 */
public class MenuManager : MonoBehaviour
{
    // Singleton instance
    private static MenuManager m_instance = null;

    /**
     * <summary> Menu to be used as the first active menu. </summary> 
     */
    public Menu StartMenu = null;

    private List<Menu> m_menuStack = new List<Menu>();
    private List<Menu> m_registeredMenus = new List<Menu>();

    [SerializeField]
    private GameObject m_okModalPrefab;

    [SerializeField]
    private Canvas m_menuCanvas;

    /**
     * <summary> CurrentMenu Property </summary>
     * Allows access to the top of the menu stack, aka the current menu.
     * <remarks> If there is not active menu, the property will be null </remarks>
     */
    public Menu CurrentMenu { 
        get {
            if (m_menuStack.Count == 0)
            {
                return null;
            }

            return m_menuStack[m_menuStack.Count - 1]; 
        } 
    }

    /**
     * <summary> Singleton getter function </summary>
     * <returns> The singleton instance of this script </returns>
     */
    public static MenuManager GetInstance()
    {
        return m_instance;
    }

    /**
     * <summary> Sets the singleton instance when this script is loaded. </summary>
     * <remarks> This function must be called before any menus attempt to register with it. </remarks>
     */
    public void Awake()
    {
        // Check for existing instance
        if (m_instance != null)
        {
            // Throw an error if there is 
            const string errMsg = "Multiple instances of a singleton script";
            Debug.LogError(errMsg);

            throw new System.Exception(errMsg);
        }

        m_instance = this;
        
        // Push start menu if it exists
        if (StartMenu != null)
        {
            PushMenu(StartMenu);
        }
    }

    /**
     * <summary> Function to check if the menu manager has a menu active or not </summary>
     * <returns> Whether there is an active menu or not. </returns>
     */
    public bool HasMenuActive()
    {
        return m_menuStack.Count > 0;
    }
    
    /**
     * <summary> Opens a new menu on top of the current menu. </summary>
     * This allows for the the new menu to be popped from the stack to return to 
     * the previous menu
     * <remarks> This function overload requires the target menu to be registered. </remarks>
     * <param name="menuName"> The name of the registered menu to be opened </param>
     */
    public void PushMenu(string menuName)
    {
        // Find menu with that name
        foreach(Menu menu in m_registeredMenus)
        {
            if (menu.GetName() == menuName)
            {
                PushMenu(menu);
                return;
            }
        }

        Debug.LogError("Menu with name: " + menuName + " not found!");
    }

    /**
     * <summary> Opens a new menu on top of the current menu. </summary>
     * This allows for the the new menu to be popped from the stack to return to 
     * the previous menu
     * <param name="menu"> The menu to be opened </param>
     */
    public void PushMenu(Menu menu)
    {
        // If there is an active menu, close / disable it
        if(HasMenuActive())
        {

            // If the menu is modal that dont disable the previous menu, 
            // but just block it from interactions
            if(menu.IsModal())
            {
                CurrentMenu.GetComponent<CanvasGroup>().interactable = false;
            }
            else
            {
                CurrentMenu.OnMenuClose();
                CurrentMenu.gameObject.SetActive(false);
            }
        }
        
        // open / enable the new menu
        menu.gameObject.SetActive(true);
        menu.OnMenuOpen();

        // push the menu to the top of the stack
        m_menuStack.Add(menu);

        GameObject sel = menu.GetDefaultSelectable();
        if(sel != null)
        {
            EventSystem.current.SetSelectedGameObject(sel);
            print("Setting selected game object " + sel.name);
        }

        PrintMenuStack();
    }

    /**
     * <summary> Removes the menu from the top of the stack, closing it and opening the 
     * next menu at the top of the stack. </summary>
     */
    public void PopMenu()
    {
        // Check if there is a menu to pop
        if (HasMenuActive())
        {
            Menu lastMenu = CurrentMenu;

            CurrentMenu.OnMenuClose();
            CurrentMenu.gameObject.SetActive(false);

            m_menuStack.RemoveAt(m_menuStack.Count - 1);

            // Open the next menu if it exists
            if (m_menuStack.Count > 0)
            { 
                CurrentMenu.gameObject.SetActive(true);
                CurrentMenu.OnMenuOpen();

                // If the previous menu was modal, then we need to reactivate interactions for this menu
                if (lastMenu.IsModal())
                {
                    CurrentMenu.GetComponent<CanvasGroup>().interactable = true;
                    Destroy(lastMenu.gameObject);
                }

                GameObject sel = CurrentMenu.GetDefaultSelectable();
                if (sel != null)
                {
                    EventSystem.current.SetSelectedGameObject(sel);
                }
            }
        }

        PrintMenuStack();
    }

    /**
     * <summary> Opens a new 'Ok' type modal </summary>
     * <param name="title"> The text to be displayed at the top of the menu </param>
     * <param name="content"> The text to be displayed at the center of the menu </param>
     * <param name="onSubmit"> The function to be called when the menu closes (can be null for no action) </param>
     */
    public void PushModalOk(string title, string content, OkModalMenu.OnSubmit onSubmit)
    {
        // Create a new modal menu 
        GameObject modal = Instantiate(m_okModalPrefab, m_menuCanvas.transform);
        OkModalMenu modalComp = modal.GetComponent<OkModalMenu>();

        // Setup the modal
        modalComp.SetTitle(title);
        modalComp.SetContent(content);
        modalComp.SetOnSubmitCallback(onSubmit);

        // Open the menu
        PushMenu(modalComp);
    }

    /**
        * <summary> Registers a menu with the menu manager </summary>
        * <param name="menu"> menu to be registered </param>
        * If the menu is not the current menu, it will be disabled.
        * <remarks> A menu is required to be registered when referring to it by name. 
        * e.g. with calls to PushMenu() </remarks>
        */
    public void AttachMenu(Menu menu)
    {
        m_registeredMenus.Add(menu);
        if(menu != CurrentMenu)
        {
            menu.gameObject.SetActive(false);
        }
    }

    /**
        * <summary> Deregisters a menu from the manager </summary>
        * <param name="menu"> menu to deregister </param>
        */
    public void DettachMenu(Menu menu)
    {
        m_registeredMenus.Remove(menu);
    }

    /**
     * <summary> Debug function to print a text representation of the menu stack to the console </summary>
     */
    public void PrintMenuStack()
    {
        string stack = "MenuStack: [";

        if (m_menuStack.Count > 0)
        {
            for (int i = 0; i < m_menuStack.Count - 1; i++)
            {
                stack += m_menuStack[i].GetName() + ", ";
            }

            stack += m_menuStack[m_menuStack.Count - 1].GetName();
        }
        stack += "]";

        Debug.Log(stack);
    }
}