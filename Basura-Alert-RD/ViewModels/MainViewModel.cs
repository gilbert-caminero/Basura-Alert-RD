using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Basura_Alert_RD.Models;
using Basura_Alert_RD.Services;

namespace Basura_Alert_RD.ViewModels;

public class MainViewModel
{
    public ObservableCollection<AlarmaBasura> Alertas { get; set; } = new();

    public ICommand CargarAlertasCommand { get; }

    public MainViewModel()
    {
        CargarAlertasCommand = new Command(async () => await CargarAlertasAsync());

        // Carga inicial
        _ = CargarAlertasAsync();
    }

    public async Task CargarAlertasAsync()
    {
        var lista = await AlarmaService.ObtenerAlertasRecientesAsync();

        Alertas.Clear();
        foreach (var alerta in lista)
        {
            Alertas.Add(alerta);
        }
    }
}