using UnityEngine;

namespace UserController
{
    public class WindowsController: IUserController
    {
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";
        
        public float GetLookDirectionX() => Input.GetAxis(MouseX);
        
        public float GetLookDirectionY() => Input.GetAxis(MouseY);

        public float GetMoveDirectionVertical() => Input.GetAxis(Vertical);

        public float GetMoveDirectionHorizontal() => Input.GetAxis(Horizontal);

        public bool IsSprinting() => Input.GetKey(KeyCode.LeftShift);
        
        public bool IsPausing() => Input.GetKeyDown(KeyCode.Escape);
    }
}