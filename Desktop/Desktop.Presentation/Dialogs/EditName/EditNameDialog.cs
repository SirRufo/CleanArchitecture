using Desktop.Presentation.Common.Interfaces;

namespace Desktop.Presentation.Dialogs.EditName
{
    public class EditNameDialog : IDialog<string>
    {
        public string Name { get; set; }
    }
}
