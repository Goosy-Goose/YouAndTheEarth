using UnityEngine;

public interface IData_Persistence
{
    public void LoadData(Game_Data data);
    public void SaveData(ref Game_Data data);
}
