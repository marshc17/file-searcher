using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearcher
{
    public static class GroupBoxExtensionMethods
    {
        public static T GetSelectedRadioBoxAsEnumValueFromTag<T>(this GroupBox groupBox)
        {
            var checkedRadioButton = groupBox
                .Controls
                .OfType<RadioButton>()
                .Cast<RadioButton>()
                .First(radioButton => radioButton.Checked);

            return (T)checkedRadioButton.Tag;
        }
    }
}
