namespace SkillButtonComponents.Presenter
{
    public interface ISkillButtonPresenter
    {
        void Initialize();
        void Uninitialize();
        void OnLearnCurrentClicked();
        void OnForgetCurrentClicked();
    }
}
