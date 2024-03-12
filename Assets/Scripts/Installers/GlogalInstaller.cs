using UnityEngine;
using Zenject;

public class GlogalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
    }
    
    private void BindInput()
    {
        Container.Bind<IInput>().To<InputHandler>().AsSingle();
    }
}