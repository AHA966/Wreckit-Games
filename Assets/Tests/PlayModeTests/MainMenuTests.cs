using System.Collections;
using NUnit.Framework;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace MenuTests
{
    public class MainMenuTests
    {
        private const string QUIT_BUTTON_NAME = "QuitButton";
        private const float MENU_CHANGE_DELAY = 0.5f;

        private GameObject m_mainMenu;
        private Button m_playButton, m_settingsButton, m_quitButton, m_createRoomMenuButton, m_joinRoomMenuButton, m_createRoomButton, m_joinRoomButton;

        [UnitySetUp]
        public IEnumerator Setup()
        {
            //Load Scene
            SceneManager.LoadScene(TestConstants.MAIN_MENU_SCENE_NAME);
            yield return new WaitUntil (() =>
                SceneManager.GetActiveScene().name == TestConstants.MAIN_MENU_SCENE_NAME);

            //Get Main Menu
            m_mainMenu = GameObject.Find(TestConstants.MAIN_MENU_NAME);
            Assert.NotNull(m_mainMenu);

            //Get menu button gameobjects
            GameObject playButton = TestUtils.FindChild(m_mainMenu, 
                TestConstants.PLAY_BUTTON_NAME);

            GameObject settingsButton = TestUtils.FindChild(m_mainMenu, 
                TestConstants.SETTINGS_BUTTON_NAME);

            GameObject quitButton = TestUtils.FindChild(m_mainMenu, 
                TestConstants.QUIT_BUTTON_NAME);
            
            GameObject createRoomMenuButton = TestUtils.FindChild(m_mainMenu, 
                TestConstants.CREATE_ROOM_MENU_BUTTON);
            
            GameObject joinRoomMenuButton = TestUtils.FindChild(m_mainMenu, 
                TestConstants.JOIN_ROOM_MENU_BUTTON);
            
            GameObject createRoomButton = TestUtils.FindChild(m_mainMenu, 
                TestConstants.CREATE_ROOM_BUTTON);

            GameObject joinRoomButton = TestUtils.FindChild(m_mainMenu, 
                TestConstants.JOIN_ROOM_BUTTON);

            //Check they Exist

            Assert.NotNull(playButton);
            Assert.NotNull(settingsButton);
            Assert.NotNull(quitButton);
            Assert.NotNull(createRoomMenuButton);
            Assert.NotNull(joinRoomMenuButton);
            Assert.NotNull(createRoomButton);
            Assert.NotNull(joinRoomButton);

            m_playButton = playButton.GetComponent<Button>();
            m_settingsButton = settingsButton.GetComponent<Button>();
            m_quitButton = quitButton.GetComponent<Button>();
            m_createRoomMenuButton = createRoomMenuButton.GetComponent<Button>();
            m_joinRoomMenuButton = joinRoomMenuButton.GetComponent<Button>();
            m_createRoomButton = createRoomButton.GetComponent<Button>();
            m_joinRoomButton = joinRoomButton.GetComponent<Button>();

            Assert.NotNull(m_playButton);
            Assert.NotNull(m_settingsButton);
            Assert.NotNull(m_quitButton);
            Assert.NotNull(m_createRoomMenuButton);
            Assert.NotNull(m_joinRoomMenuButton);
            Assert.NotNull(m_createRoomButton);
            Assert.NotNull(m_joinRoomButton);


            
        }

        [UnityTest]
        public IEnumerator PlayButtonTest()
        {
            //Click Play Button
            m_playButton.OnClick.Invoke();

            yield return new WaitForSeconds(MENU_CHANGE_DELAY);

            // Check the correct Menu is active
            Assert.AreEqual(
                MenuManager.GetInstance().CurrentMenu.GetName(),
                TestConstants.CREATE_OR_JOIN_MENU_NAME
            );

            Assert.IsTrue(
                MenuManager.GetInstance.CurrentMenu.gameObject.activeSelf
            );
        }

        [UnityTest]
        public IEnumerator SettingsButtonTest()
        {
            //Click Play Button
            m_settingsButton.OnClick.Invoke();

            yield return new WaitForSeconds(MENU_CHANGE_DELAY);

            // Check the correct Menu is active
            Assert.AreEqual(
                MenuManager.GetInstance().CurrentMenu.GetName(),
                TestConstants.SETTINGS_MENU_NAME
            );

            Assert.IsTrue(
                MenuManager.GetInstance.CurrentMenu.gameObject.activeSelf
            );
        }

        [UnityTest]
        public IEnumerator CreateRoomMenuButtonTest()
        {
            //Click Play Button
            m_createRoomMenuButton.OnClick.Invoke();

            yield return new WaitForSeconds(MENU_CHANGE_DELAY);

            // Check the correct Menu is active
            Assert.AreEqual(
                MenuManager.GetInstance().CurrentMenu.GetName(),
                TestConstants.CREATE_ROOM_MENU_NAME
            );

            Assert.IsTrue(
                MenuManager.GetInstance.CurrentMenu.gameObject.activeSelf
            );
        }

        [UnityTest]
        public IEnumerator JoinRoomMenuButtonTest()
        {
            //Click Play Button
            m_joinRoomMenuButton.OnClick.Invoke();

            yield return new WaitForSeconds(MENU_CHANGE_DELAY);

            // Check the correct Menu is active
            Assert.AreEqual(
                MenuManager.GetInstance().CurrentMenu.GetName(),
                TestConstants.JOIN_ROOM_MENU_NAME
            );

            Assert.IsTrue(
                MenuManager.GetInstance.CurrentMenu.gameObject.activeSelf
            );
        }

        [UnityTest]
        public IEnumerator JoinRoomMenuButtonTest()
        {
            //Click Play Button
            m_joinRoomMenuButton.OnClick.Invoke();

            yield return new WaitForSeconds(MENU_CHANGE_DELAY);

            // Check the correct Menu is active
            Assert.AreEqual(
                MenuManager.GetInstance().CurrentMenu.GetName(),
                TestConstants.JOIN_ROOM_MENU_NAME
            );

            Assert.IsTrue(
                MenuManager.GetInstance.CurrentMenu.gameObject.activeSelf
            );
        }

        [UnityTest]
        public IEnumerator CreateRoomButtonTest()
        {
            //Click Play Button
            m_createRoomButton.OnClick.Invoke();

            yield return new WaitForSeconds(MENU_CHANGE_DELAY);

            // Check the correct Menu is active
            Assert.AreEqual(
                MenuManager.GetInstance().CurrentMenu.GetName(),
                TestConstants.PLAY_MENU_NAME
            );

            Assert.IsTrue(
                MenuManager.GetInstance.CurrentMenu.gameObject.activeSelf
            );
        }

        [UnityTest]
        public IEnumerator JoinRoomButtonTest()
        {
            //Click Play Button
            m_joinRoomButton.OnClick.Invoke();

            yield return new WaitForSeconds(MENU_CHANGE_DELAY);

            // Check the correct Menu is active
            Assert.AreEqual(
                MenuManager.GetInstance().CurrentMenu.GetName(),
                TestConstants.LOBBY_MENU_NAME
            );

            Assert.IsTrue(
                MenuManager.GetInstance.CurrentMenu.gameObject.activeSelf
            );
        }

        [UnityTearDown]
        public IEnumerator PhotonCleanup()
        {
            // Disconnect from photon
            PhotonNetwork.Disconnect();

            yield break;
        }


    }


}
