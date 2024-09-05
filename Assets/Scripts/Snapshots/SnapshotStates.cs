using System.Collections;
using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

namespace Snap
{
    public class SnapshotStates : MonoBehaviour
    {
        public CameraStates _currentCameraState = CameraStates.MainCamera;

        private void Start()
        {
            ButtonConfig.e_OnButtonConfig += EnableConfigScene;
        }

        public void EnableConfigScene()
        {
            _currentCameraState = _currentCameraState != CameraStates.MainCamera ? CameraStates.SnapshotCamera : CameraStates.MainCamera;
        }

        public void ChangeState(CameraStates cameraState)
        {
            _currentCameraState = cameraState;

            switch (cameraState)
            {
                case CameraStates.SnapshotCamera:
                    
                    break;

                case CameraStates.MainCamera:
                    
                    break;
            }
        }
    }

    public enum CameraStates
    {
        MainCamera,
        SnapshotCamera,
    }
}