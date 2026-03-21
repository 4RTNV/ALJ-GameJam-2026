using UnityEngine;

namespace _Project.Infrastructure
{
    public class CameraProvider : ICameraProvider
    {
        public Camera Camera { get; private set; }

        public void SetCamera(Camera cameraInstance)
        {
            Camera = cameraInstance;
        }
    }
}