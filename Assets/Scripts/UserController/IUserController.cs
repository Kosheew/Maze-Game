namespace UserController
{
  public interface IUserController
  {
    public float GetLookDirectionX();
    public float GetLookDirectionY();
    public float GetMoveDirectionVertical();
    public float GetMoveDirectionHorizontal();
    public bool IsSprinting();
  
    public bool IsPausing();
  }
}
