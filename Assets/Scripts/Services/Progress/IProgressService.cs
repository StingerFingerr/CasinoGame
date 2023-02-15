namespace Services.Progress
{
    public interface IProgressService: IService
    {
        Progress Progress { get; }
        
        Progress LoadProgress();
        void SaveProgress();
    }
}