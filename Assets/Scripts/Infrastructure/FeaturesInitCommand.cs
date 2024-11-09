using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class FeaturesInitCommand
    {
        private InitializationCommandExecutor _initializationCommandExecutor;

        public FeaturesInitCommand(DiContainer diContainer)
        {
            _initializationCommandExecutor = new InitializationCommandExecutor(diContainer);
            CreateInitializationPipe();
        }

        private void CreateInitializationPipe()
        {
            _initializationCommandExecutor.Add<ObjectInteractionFeatureInitCommand>();
            _initializationCommandExecutor.Add<MessageFeatureInitCommand>();
            _initializationCommandExecutor.Add<CameraFeatureInitCommand>();
            _initializationCommandExecutor.Add<AssetFeatureInitCommand>();
            _initializationCommandExecutor.Add<LeveFeatureInitCommand>();
            _initializationCommandExecutor.Add<CounterFeatureInitCommand>();
            _initializationCommandExecutor.Add<SceneFeatureInitCommand>();
            _initializationCommandExecutor.Add<HiddenObjectFeatureInitCommand>();
        }
    }
}