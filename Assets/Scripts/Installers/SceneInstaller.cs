using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private CharacterControl _characterControlPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Camera _cameraPrefab;
    
    public override void InstallBindings()
    {
        BindCharacter();
        BindCamera();
    }
    
    private void BindCharacter()
    {
        Container
            .Bind<CharacterControl>()
            .FromComponentInNewPrefab(_characterControlPrefab)
            .AsSingle()
            .WithArguments(_spawnPoint)
            .NonLazy();
    }

    private void BindCamera()
    {
        Container
            .Bind<CameraController>()
            .FromComponentInNewPrefab(_cameraPrefab)
            .AsSingle()
            .NonLazy();
    }
}