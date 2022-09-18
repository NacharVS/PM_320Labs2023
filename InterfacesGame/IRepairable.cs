using System;
namespace InterfacesGame
{
    public interface IRepairable
    {
        int Durability { get; set; }

        void Repair();

        void ShowInfo();
    }
}
