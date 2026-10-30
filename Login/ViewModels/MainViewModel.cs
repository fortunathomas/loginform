using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
namespace Login.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Username { get; set; } = string.Empty;
    [ObservableProperty] public partial string Password { get; set; } = string.Empty;
    [ObservableProperty] public partial string LoginText { get; set; } = "Inserisci la password";
    [ObservableProperty] public partial string ButtonText { get; set; } = "Login";

    [ObservableProperty] public partial List<string> ListaNomi { get; set; } = new List<string> { "Marius", "Nicola", "Thomas" };

    [ObservableProperty] public partial List<string> ListaPassword { get; set; } = new List<string> { "scacchio", "epporca", "google-maps" };
    private bool IsLogged { get; set; }


    public void Login()
    {

        if (string.IsNullOrWhiteSpace(Password))
        {
            LoginText = "Password non valida";
            return;
        }

        if (!IsLogged)
        {
            if (Validate())
            {
                IsLogged = true;
                LoginText = $"Benvenuto {Username}";
                ButtonText = "Logout";
                return;
            }
            
            LoginText = "Password errata";
        }
        
        else
        {
            IsLogged = false;
            LoginText = $"Arrivederci {Username}";
            ButtonText = "Login";
        }
    }

    private bool Validate()
    {
        for (int i = 0; i < ListaNomi.Count; i++)
        {
            if (Username == ListaNomi[i] && Password == ListaPassword[i])
                return true;
        }

        return false;
    }
}