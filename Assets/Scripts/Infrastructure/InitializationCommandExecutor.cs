using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class InitializationCommandExecutor
    {
        private DiContainer _container;
        private List<BaseFeatureInitCommand> _baseFeatureInitCommands;

        public InitializationCommandExecutor(DiContainer diContainer)
        {
            _container = diContainer;
            _baseFeatureInitCommands = new List<BaseFeatureInitCommand>();
        }

        public void Add<TFeatureInitCommand>() where TFeatureInitCommand : BaseFeatureInitCommand, new()
        {
           
            TFeatureInitCommand command = new TFeatureInitCommand();
            _baseFeatureInitCommands.Add(command);
            command.BindDependencies(_container);
        }
    }
}