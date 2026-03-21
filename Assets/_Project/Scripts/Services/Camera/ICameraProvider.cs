using UnityEngine;

namespace _Project.Infrastructure
{
    public interface ICameraProvider
    {
        public Camera Camera { get; }
        public void SetCamera(Camera cameraInstance);
    }
}