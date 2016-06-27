using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VendorMaintenance
{
    class Validator
    {
        private static string title = "Entry Error";

        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag.ToString() + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag.ToString() + " is a required field.", Title);
                    comboBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be a decimal value.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be an integer value.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsStateZipCode(TextBox textBox,
            int firstZip, int lastZip)
        {
            int zipCode = Convert.ToInt32(textBox.Text);
            if (zipCode <= firstZip || zipCode >= lastZip)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be within this range: " +
                    firstZip + " to " + lastZip + ".", Title);
                textBox.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsPhoneNumber(TextBox textBox)
        {
            string phoneChars = textBox.Text.Replace(".", "");
            try
            {
                Convert.ToInt64(phoneChars);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be in this format: " +
                    "999.999.9999.", Title);
                textBox.Focus();
                return false;
            }
        }
    }
}
