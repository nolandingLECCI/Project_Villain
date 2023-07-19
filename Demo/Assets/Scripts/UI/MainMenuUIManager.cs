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
        [SerializeField] ShopScreen m_ShopModalScreen;
        [SerializeField] VilScreen m_VilModalScreen;
        [SerializeField] EducationScreen m_EducationModalScreen;
        [SerializeField] EmployScreen m_EmployModalScreen;
        [SerializeField] QuestScreen m_QuestModalScreen;
        [SerializeField] MissionScreen m_MissionModalScreen;

        [Header("Toolbars")]
        [Tooltip("Toolbars remain active at all times unless explicitly disabled.")]
        [SerializeField] Topbar m_Topbar;
        

        List<MenuScreen> m_AllModalScreens = new List<MenuScreen>();

        UIDocument m_MainMenuDocument;
        public UIDocument MainMenuDocument => m_MainMenuDocument;

        void OnEnable()
        {
            m_MainMenuDocument = GetComponent<UIDocument>();
            SetupModalScreens();
            ShowHomeScreen();
            //ShowEducationScreen();
        }

        void Start()
        {
            Time.timeScale = 1f;
        }

        void SetupModalScreens()
        {
            if (m_HomeModalScreen != null)
                m_AllModalScreens.Add(m_HomeModalScreen);

            if (m_ShopModalScreen != null)
                m_AllModalScreens.Add(m_ShopModalScreen);

            if (m_VilModalScreen != null)
                m_AllModalScreens.Add(m_VilModalScreen);

            if (m_EducationModalScreen != null)
                m_AllModalScreens.Add(m_EducationModalScreen);

            if (m_EmployModalScreen != null)
                m_AllModalScreens.Add(m_EmployModalScreen);

            if (m_QuestModalScreen != null)
                m_AllModalScreens.Add(m_QuestModalScreen);

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

        public void ShowShopScreen()
        {
            ShowModalScreen(m_ShopModalScreen);
        }

        public void ShowVilScreen()
        {
            ShowModalScreen(m_VilModalScreen);
        }
       
        public void ShowEducationScreen()
        {
            ShowModalScreen(m_EducationModalScreen);
        }

        public void ShowEmployScreen()
        {
            ShowModalScreen(m_EmployModalScreen);
        }

        public void ShowQuestScreen()
        {
            ShowModalScreen(m_QuestModalScreen);
        }

        public void ShowMissionScreen()
        {
            ShowModalScreen(m_MissionModalScreen);
        }

    }
