
public abstract class Saveable
{
    public string ID { get; private set; }

    public Saveable(string id)
    {
        ID = id;

        IdController.AddId(ID);

        SaveLoad.SavingStarted += Save;
        SaveLoad.LoadingStarted += Load;
    }

    ~Saveable()
    {
        IdController.RemoveId(ID);

        SaveLoad.SavingStarted -= Save;
        SaveLoad.LoadingStarted -= Load;
    }

    protected abstract void ProcessSave();

    protected abstract void ProcessLoad();

    private void Save()
    {
        SaveLoad.IncSaveLoadObject();
        ProcessSave();
        SaveLoad.DecSaveLoadObject();
    }

    private void Load()
    {
        SaveLoad.IncSaveLoadObject();
        ProcessLoad();
        SaveLoad.DecSaveLoadObject();
    }
}
