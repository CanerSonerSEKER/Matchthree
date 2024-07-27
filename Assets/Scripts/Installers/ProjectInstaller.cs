using Events;
using Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        private ProjectEvents _projectEvents;
        private InputEvents _inputEvents;
        private GridEvents _gridEvents;
        private ProjectSettings _projectSettings;
        private AudioEvents _audioEvents;
        
        
        public override void InstallBindings()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            
            InstallEvents();
            InstallPlayerData();
            InstallSettings();
        }
        
        //2
        private void InstallPlayerData()
        {
            Container.BindInterfacesAndSelfTo<PlayerData>().AsSingle();
        }
        
        //2
        
        private void InstallSettings()
        {
            _projectSettings = Resources.Load<ProjectSettings>(EnvVar.ProjectSettingsPath);
            Container.BindInstance(_projectSettings).AsSingle();
        }

        private void InstallEvents()
        { 
            _projectEvents = new ProjectEvents();
            Container.BindInstance(_projectEvents).AsSingle();
            
            _inputEvents = new InputEvents();
            Container.BindInstance(_inputEvents).AsSingle();

            _gridEvents = new GridEvents();
            Container.BindInstance(_gridEvents).AsSingle();

            _audioEvents = new AudioEvents();
            Container.BindInstance(_audioEvents).AsSingle();
        }
        
        

        private void Awake()
        {
            RegisterEvents();
        }

        public override void Start()
        {
            
            _projectEvents.ProjectStarted?.Invoke();
        }

        private static void LoadScene(string sceneName) {SceneManager.LoadScene(sceneName);}

        private void RegisterEvents()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            MainMenuEvents.NewGameBTN += OnNewGameBTN;
        }

        private void OnNewGameBTN()
        {
            LoadScene("Main");
        }

        private void OnSceneLoaded(Scene loadedScene, LoadSceneMode arg1)
        {
            if(loadedScene.name == EnvVar.LoginSceneName)
            {
                LoadScene(EnvVar.MainSceneName);
            }
        }
    }
}