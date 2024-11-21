using UnityEngine;
namespace Characters.Character_Interfaces
{
    public interface ITargetHandler
    {
        Transform CurrentTarget { get; }
    }
}