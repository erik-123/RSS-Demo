using RSS_Demo.Data;
using RSS_Demo.Logik;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RSS_Demo.Logik
{
}

public static class Validering
{
    
    public static bool validateSelectedCategory(string category, string modifier)
    {
        switch (modifier)
        {
            case "remove":
                string podcasts = "";
                if (PodcastHandler.lookupTrue(category, "podcast"))
                {
                    foreach(var podcast in PodcastHandler.getPodcasts(category))
                    {
                        podcasts = podcast.Title + ", " + podcasts;
                    }
                    MessageBox.Show("Följande podcasts tillhör "+ category +" kategorin: \n"+ podcasts +" \n ändra kategori för podcastsen för att ta bort kategorin" );
                    break;
                }
                MessageBox.Show("Kategori borttagen");
                return true;
            case "add":
                if(PodcastHandler.lookupTrue(category, "category"))
                {
                    MessageBox.Show("Kategorin finns redan i listan");
                    break;
                }
                return true;
            case "edit":
                if (PodcastHandler.lookupTrue(category, "podcast"))
                {
                    MessageBox.Show("Podcasts tillhör den valda kategorin, vänligen ändra kategori för dessa podcasts för att ändra");
                    break;
                }
                return true;
        }
        return false;
    }
    public static bool CheckIfTextfieldsIsEmpty(TextBox textBox)
    {
        if (textBox.Text.Length > 0)
        {
            return true;
        }

            MessageBox.Show("Vänligen fyll i alla fält");
            return false;
    }

    public static bool CheckIfTextfieldsHasANumber(TextBox textBox)
    {
        var s = textBox.Text.Trim();

        foreach (char c in s)
        {
            if (!Char.IsLetter(c))
            {
                return false;
                throw new RSS_Demo.Logik.ValidationException("Textfältet innehåller en eller flera siffror");
            }
        }
        return true;
    }

    public static bool CheckIfComboboxIsEmpty(ComboBox cb)
    {
        if (cb.SelectedItem != null)
        {
            return true;
        }
        else
        {
            MessageBox.Show("Comboboxen är tom!");
            return false;
        }
    }

    public static string CheckIfURLIsValid(string url)
    {
        try
        {
            var podcastData = XDocument.Load(url);
            if (podcastData.Root.Name == "rss")
            {
                return url;
            }
            return "";
        }
        catch (Exception)
        {
            MessageBox.Show("Du har skrivit in en felaktig url!");
            return "";
        }
    }

    public static bool CheckIfCategoryIsAvailable(TextBox textBox)
    {
        var befintligaKategorier = CategoryRepo.LoadCategories();

        foreach (var kategori in befintligaKategorier)
        {
            if (textBox.Text == kategori)
            {
                MessageBox.Show("Det finns i kategorilistan");
                return false;
            }
            
        }
        return true;
    }
}