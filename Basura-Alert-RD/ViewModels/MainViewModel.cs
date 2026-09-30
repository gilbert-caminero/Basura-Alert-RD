using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Basura_Alert_RD.Models;
using Basura_Alert_RD.Services;

namespace Basura_Alert_RD.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly AlarmaService _alarmaService;
    private string _estadoUltimaAlarma = "Sin avisos recientes en tu zona";
    private bool _estaCargando;

    public ObservableCollection<AlarmaBasura> ListaAlertas { get; } = new();

    public string EstadoUltimaAlarma
    {
        get => _estadoUltimaAlarma;
        set { _estadoUltimaAlarma = value; OnPropertyChanged(); }
    }

    public bool EstaCargando
    {
        get => _estaCargando;
        set { _estaCargando = value; OnPropertyChanged(); }
    }

    public ICommand ActivarAlarmaCommand { get; }

    public MainViewModel()
    {
        _alarmaService = new AlarmaService();
        ActivarAlarmaCommand = new Command(async () => await ActivarAlarmaAsync());
    }

    private async Task ActivarAlarmaAsync()
    {
        if (EstaCargando) return;
        EstaCargando = true;

        bool exito = await _alarmaService.EmitirAlarmaAsync("Sector Central", "Vecino Anónimo");

        if (exito)
        {
            var recientes = await _alarmaService.ObtenerAlertasRecientesAsync();
            ListaAlertas.Clear();
            foreach (var alerta in recientes)
            {
                ListaAlertas.Add(alerta);
            }

            EstadoUltimaAlarma = $"¡Alarma enviada! Último aviso a las {DateTime.Now:hh:mm tt}";
        }

        EstaCargando = false;
    }

    #region INotifyPropertyChanged Implementation
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}