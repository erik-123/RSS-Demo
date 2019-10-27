using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RSS_Demo
{
    }

    public static class Validering
    {
        public static bool kontrolleraOmTextfaltArTomt(TextBox textBox)
        {

            if (textBox.Text.Trim() == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    
        public static bool kontrollOmTextfaltHarSiffra(TextBox textBox)
        {
        var s = textBox.Text.Trim();

        foreach (char c in s)
        {
            if (!Char.IsLetter(c))
                return false;
        }
        return true;
              
    }
        public static bool KontrollOmComboBoxArTom(ComboBox cb)
        {
            return cb.SelectedItem != null ? true : false;

        }
    }

