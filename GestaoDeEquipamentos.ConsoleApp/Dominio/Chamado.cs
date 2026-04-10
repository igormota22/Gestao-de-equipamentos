using System;

namespace GestaoDeEquipamentos.ConsoleApp.Dominio;

public class Chamado
{
    public string id;
    public string titulo;
    public string? descricao;
    public DateTime dataDeAbertura = DateTime.Now;
    public Equipamento equipamento;


    public int ObterDiasDecorridos()
    {
        TimeSpan diasDecorridos = DateTime.Now.Subtract(dataDeAbertura);

        return diasDecorridos.Days;
    }
}

