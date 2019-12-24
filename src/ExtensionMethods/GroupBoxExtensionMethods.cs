using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearcher.ExtensionMethods
{
    public static class GroupBoxExtensionMethods
    {
        public static T GetSelectedRadioButtonAsEnumValueFromTag<T>(this GroupBox groupBox)
        {
            var checkedRadioButton = groupBox.GetSelectedRadioButton();

            return (T)checkedRadioButton.Tag;
        }

        public static RadioButton GetSelectedRadioButton(this GroupBox groupBox)
        {
            return groupBox
                .Controls
                .OfType<RadioButton>()
                .Cast<RadioButton>()
                .First(radioButton => radioButton.Checked);
        }
    }
}
