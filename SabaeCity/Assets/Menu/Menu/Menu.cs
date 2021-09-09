using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;

public class Menu : MonoBehaviour
{
    public static SceneSelection sceneSelection = SceneSelection.Inactive;
    enum ButtonColumn
    {
        LEFT, RIGHT, OTHERS
    };

    List<Button> m_leftColumnButtons = new List<Button>();
    List<Button> m_rightColumnButtons = new List<Button>();

    class MenuData
    {
        public int leftColumnIdx = 0;
        public int rightColumnIdx = 0;
        public ButtonColumn activeColumn = ButtonColumn.RIGHT;
    }
    MenuData m_menuData = new MenuData();

    class SceneSelectionEvent
    {
        public ButtonColumn moveLeftRight = ButtonColumn.OTHERS;
        public int moveUpDown = 0;
        public bool selectionUpdate = false;
        public bool invoke = false;
    }
    SceneSelectionEvent m_sceneSelectionEvent = new SceneSelectionEvent();

    float m_dPadX = 0F;
    float m_dPadY = 0F;

    void AddOnClickListeners(String scene, ButtonColumn column)
    {
        var button = GameObject.Find("Button" + scene).GetComponent<Button>();

        switch (column)
        {
            case ButtonColumn.LEFT:
                m_leftColumnButtons.Add(button);
                break;
            case ButtonColumn.RIGHT:
                m_rightColumnButtons.Add(button);
                break;
            case ButtonColumn.OTHERS:
                break;
        }

        button.onClick.AddListener(
            delegate
            {
                switch (scene)
                {
                    case "Guide":
                        sceneSelection = SceneSelection.Guide;
                        LoadScene("SabaeCity");
                        break;

                    case "Bus":
                        sceneSelection = SceneSelection.Bus;
                        LoadScene("SabaeCity");
                        break;

                    case "Drone":
                        sceneSelection = SceneSelection.Drone;
                        LoadScene("SabaeCity");
                        break;

                    case "Unused1":
                        sceneSelection = SceneSelection.Bus;
                        //LoadScene("...");
                        break;
                    case "Unused2":
                        sceneSelection = SceneSelection.Bus;
                        //LoadScene("...");
                        break;

                    case "Quit":
                        Application.Quit();
                        break;
                }
            }
        );
    }

    void Start()
    {
        // Add buttons to listeners
        AddOnClickListeners("Guide", ButtonColumn.LEFT);
        AddOnClickListeners("Bus", ButtonColumn.LEFT);
        AddOnClickListeners("Drone", ButtonColumn.LEFT);

        AddOnClickListeners("Unused1", ButtonColumn.RIGHT);
        AddOnClickListeners("Unused2", ButtonColumn.RIGHT);

        AddOnClickListeners("Quit", ButtonColumn.OTHERS);

        // Menu data persistency
        if (!File.Exists(Properties.MENU_DATA_FILE))
        {
            var obj = JsonConvert.SerializeObject(m_menuData);
            File.WriteAllText(Properties.MENU_DATA_FILE, obj);
        }
        var serObj = File.ReadAllText(Properties.MENU_DATA_FILE);
        m_menuData = JsonConvert.DeserializeObject<MenuData>(serObj);

        Debug.Log($"Menu data read: {serObj}");

        // Button selection initialization
        SelectButton();
    }

    private void Update()
    {
        ProcessGamepad();

        if (m_sceneSelectionEvent.selectionUpdate)
        {
            SelectButton();
            m_sceneSelectionEvent.selectionUpdate = false;
        }
        else if (m_sceneSelectionEvent.invoke)
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
        }
    }

    void SelectButton()
    {

        switch (m_sceneSelectionEvent.moveLeftRight)
        {
            case ButtonColumn.RIGHT:
                m_menuData.activeColumn = ButtonColumn.RIGHT;
                break;
            case ButtonColumn.LEFT:
                m_menuData.activeColumn = ButtonColumn.LEFT;
                break;
            default:
                break;
        }

        switch (m_sceneSelectionEvent.moveUpDown)
        {
            case -1:  // Down
                if (m_menuData.activeColumn == ButtonColumn.LEFT)
                {
                    if (m_menuData.leftColumnIdx < (m_leftColumnButtons.Count - 1)) m_menuData.leftColumnIdx++;
                }
                else if (m_menuData.activeColumn == ButtonColumn.RIGHT)
                {
                    if (m_menuData.rightColumnIdx < (m_rightColumnButtons.Count - 1)) m_menuData.rightColumnIdx++;
                }
                break;
            case 1:  // Up
                if (m_menuData.activeColumn == ButtonColumn.LEFT)
                {
                    if (m_menuData.leftColumnIdx > 0) m_menuData.leftColumnIdx--;
                }
                else if (m_menuData.activeColumn == ButtonColumn.RIGHT)
                {
                    if (m_menuData.rightColumnIdx > 0) m_menuData.rightColumnIdx--;
                }
                break;
            default:
                break;
        }

        EventSystem.current.SetSelectedGameObject(null);

        if (m_menuData.activeColumn == ButtonColumn.LEFT)
        {
            m_leftColumnButtons[m_menuData.leftColumnIdx].Select();
        }
        else if (m_menuData.activeColumn == ButtonColumn.RIGHT)
        {
            m_rightColumnButtons[m_menuData.rightColumnIdx].Select();
        }

    }

    void ProcessGamepad()
    {
        // Logicool Gamepad F310 start button
        m_sceneSelectionEvent.invoke = Input.GetKeyDown(KeyCode.Joystick1Button7);

        float dpadX = Input.GetAxis("DPadX");
        if (dpadX > 0 && m_dPadX == 0F) {
            m_sceneSelectionEvent.moveLeftRight = ButtonColumn.RIGHT;
            m_sceneSelectionEvent.moveUpDown = 0;
            m_sceneSelectionEvent.selectionUpdate = true;
        } else if (dpadX < 0 && m_dPadX == 0F) {
            m_sceneSelectionEvent.moveLeftRight = ButtonColumn.LEFT;
            m_sceneSelectionEvent.moveUpDown = 0;
            m_sceneSelectionEvent.selectionUpdate = true;
        }
        if (dpadX == 0F) {
            m_dPadX = 0F;
        } else
        {
            m_dPadX = dpadX;
        }

        float dpadY = Input.GetAxis("DPadY");
        if (dpadY > 0 && m_dPadY == 0F) {
            m_sceneSelectionEvent.moveLeftRight = ButtonColumn.OTHERS;
            m_sceneSelectionEvent.moveUpDown = 1;
            m_sceneSelectionEvent.selectionUpdate = true;
        } else if (dpadY < 0 && m_dPadY == 0F)
        {
            m_sceneSelectionEvent.moveLeftRight = ButtonColumn.OTHERS;
            m_sceneSelectionEvent.moveUpDown = -1;
            m_sceneSelectionEvent.selectionUpdate = true;
        }
        if (dpadY == 0F)
        {
            m_dPadY = 0F;
        }
        else
        {
            m_dPadY = dpadY;
        }
    }

    void LoadScene(string scene)
    {
        var serObj = JsonConvert.SerializeObject(m_menuData);
        Debug.Log($"Menu data: {serObj}");
        File.WriteAllText(Properties.MENU_DATA_FILE, serObj);

        SceneManager.LoadScene(scene);
    }
}