using RSS_Demo.Data;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RSS_Demo
{
}

public static class Validering
{
    public static bool KontrolleraOmTextfaltArTomt(TextBox textBox)
    {
        if (textBox.Text.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
           throw new RSS_Demo.ValidationException("Vänligen fyll i alla fält");
        }
    }

   public static bool KontrollOmTextfaltHarSiffra(TextBox textBox)
   {
       var s = textBox.Text.Trim();

        foreach (char c in s)
        {
            if (!Char.IsLetter(c))
            {

                return false;
                throw new RSS_Demo.ValidationException("Textfältet innehåller en eller flera siffror");
            }
        }
        return true;
    }

    public static bool KontrollOmComboBoxArTom(ComboBox cb)
    {
        if( cb.SelectedItem  != null)
        {
            return true;
        }
        else {
            return false; 
        }
        
    }

    public static string KontrolleraOmURLArGiltig(string url)
    {
        try { var podcastData = XDocument.Load(url); return url; }
        catch (Exception)
        {
            MessageBox.Show("Du har skrivit in ett felaktigt url!");
            return "";
            
        }
    }
        public static bool kontrolleraOmKategoriFinns(TextBox textBox)
        {
           var befintligaKategorier = CategoryRepo.LoadCategories();

            foreach(var kategori in befintligaKategorier)
        {
            if(textBox.Text == kategori)
            {
                MessageBox.Show("Det finns i kategorilistan");
                return false;
            }
        }
            return true;

        }
    }


