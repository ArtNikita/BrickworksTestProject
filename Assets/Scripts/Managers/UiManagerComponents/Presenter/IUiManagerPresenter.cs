using SkillButtonComponents.View;

namespace Managers.UiManagerComponents.Presenter
{
    public interface IUiManagerPresenter
    {
        void Initialize();
        void Uninitialize();
        void SkillButtonClicked(ISkillButtonView skillButton);
    }
}