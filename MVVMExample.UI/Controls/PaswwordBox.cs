using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVMExample.UI.Controls
{
    public class PaswwordBox : WaterMarkTextBox
    {
        public static readonly DependencyProperty PasswordCharProperty =
           System.Windows.Controls.PasswordBox.PasswordCharProperty.AddOwner(typeof(PasswordBox),
               new FrameworkPropertyMetadata('●'));

        public char PasswordChar
        {
            get => (char)GetValue(PasswordCharProperty);
            set => SetValue(PasswordCharProperty, value);
        }
    }
}
