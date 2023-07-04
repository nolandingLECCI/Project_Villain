using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Serialization;
using System;

[RequireComponent(typeof(UIDocument))]
    public class MainMenuUIManager : MonoBehaviour
    {

        [Header("Modal Menu Screens")]
        [Tooltip("Only one modal interface can appear on-screen at a time.")]
        [SerializeField] HomeScreen m_HomeModalScreen;
        [SerializeField] EducationScreen m_EducationModalScreen;
        [SerializeField] EmployScreen m_EmployModalScreen;
        [SerializeField] MissionScreen m_MissionModalScreen;

        List<MenuScreen> m_AllModalScreens = new List<MenuScreen>();

        UIDocument m_MainMenuDocument;
        public UIDocument MainMenuDocument => m_MainMenuDocument;

        void OnEnable()
        {
            m_MainMenuDocument = GetComponent<UIDocument>();
            SetupModalScreens();
            ShowHomeScreen();
        }

        void Start()
        {
            Time.timeScale = 1f;
        }

        void SetupModalScreens()
        {
            if (m_HomeModalScreen != null)
                m_AllModalScreens.Add(m_HomeModalScreen);

            if (m_EducationModalScreen != null)
                m_AllModalScreens.Add(m_EducationModalScreen);

            if (m_EmployModalScreen != null)
                m_AllModalScreens.Add(m_EmployModalScreen);

            if (m_MissionModalScreen != null)
                m_AllModalScreens.Add(m_MissionModalScreen);

        }

      
        void ShowModalScreen(MenuScreen modalScreen)
        {
            foreach (MenuScreen m in m_AllModalScreens)
            {
                if (m == modalScreen)
                {
                    m?.ShowScreen();
                }
                else
                {
                    m?.HideScreen();
                }
            }
        }

      
        public void ShowHomeScreen()
        {
            ShowModalScreen(m_HomeModalScreen);
        }

       
        public void ShowEducationScreen()
        {
            ShowModalScreen(m_EducationModalScreen);
        }

        public void ShowEmployScreen()
        {
            ShowModalScreen(m_EmployModalScreen);
        }

        public void ShowMissionScreen()
        {
            ShowModalScreen(m_MissionModalScreen);
        }

    }
