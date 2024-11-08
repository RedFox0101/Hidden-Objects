using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public abstract class BaseFeatureInitCommand
    {
        public abstract void BindDependencies(DiContainer DiContainer);

    }
}