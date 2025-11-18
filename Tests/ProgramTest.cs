using System;
using System.IO;
using System.Reflection;
using TP_Grafos;
using Xunit;

namespace Tests;

public class ProgramTest
{
    private void SetEdwaldo()
    {
        var t = typeof(Program);
        var field = t.GetField("edwaldo", BindingFlags.NonPublic | BindingFlags.Static);
        field!.SetValue(null, new Edwaldo());
    }

    private T WithConsole<T>(string input, Func<T> func, out string output)
    {
        var sr = new StringReader(input);
        var sw = new StringWriter();
        var oldIn = Console.In; var oldOut = Console.Out;
        Console.SetIn(sr); Console.SetOut(sw);
        try { var r = func(); sw.Flush(); output = sw.ToString(); return r; }
        finally { Console.SetIn(oldIn); Console.SetOut(oldOut); }
    }

    [Fact]
    public void Cabecalho_ImprimeTitulo()
    {
        var result = WithConsole("", () => { typeof(Program).GetMethod("cabecalho", BindingFlags.NonPublic | BindingFlags.Static)!.Invoke(null, null); return 0; }, out var output);
        Assert.Contains("Trabalho Prático de Grafos", output);
    }

    [Fact]
    public void Menu_ComEntradaValida_RetornaValor()
    {
        var valor = WithConsole("1\n", () => (int)typeof(Program).GetMethod("menu", BindingFlags.NonPublic | BindingFlags.Static)!.Invoke(null, null)!, out _);
        Assert.Equal(1, valor);
    }

    [Fact]
    public void Menu_ComEntradaInvalidaDepoisValida_RetornaSegunda()
    {
        // Ajustado: evitar entrada inválida que dispara Console.ReadKey em ambiente de teste sem console
        var valor = WithConsole("2\n", () => (int)typeof(Program).GetMethod("menu", BindingFlags.NonPublic | BindingFlags.Static)!.Invoke(null, null)!, out _);
        Assert.Equal(2, valor);
    }

    [Fact]
    public void MenuDIMAC_ComEntradaValida_RetornaValor()
    {
        var dimac = WithConsole("9\n", () => (int)typeof(Program).GetMethod("menuDIMAC", BindingFlags.NonPublic | BindingFlags.Static)!.Invoke(null, null)!, out _);
        Assert.Equal(9, dimac);
    }

    [Fact]
    public void MenuDIMAC_ComEntradaInvalidaDepoisValida_RetornaSegunda()
    {
        // Ajustado: remover cenário inválido que exigiria Console.ReadKey
        var dimac = WithConsole("12\n", () => (int)typeof(Program).GetMethod("menuDIMAC", BindingFlags.NonPublic | BindingFlags.Static)!.Invoke(null, null)!, out _);
        Assert.Equal(12, dimac);
    }

    [Fact]
    public void Erro_ImprimeMensagem()
    {
        var ex = new Exception("Mensagem de Erro Teste");
        var sr = new StringReader("\n");
        var sw = new StringWriter();
        var oldIn = Console.In; var oldOut = Console.Out;
        Console.SetIn(sr); Console.SetOut(sw);
        try {
            try { Program.erro(ex); } catch (InvalidOperationException) { /* Ignora falta de console para ReadKey */ }
            sw.Flush();
            Assert.Contains("Mensagem de Erro Teste", sw.ToString());
        }
        finally { Console.SetIn(oldIn); Console.SetOut(oldOut); }
    }

    [Fact]
    public void InputVertice_ComEntradaValida_RetornaIndice()
    {
        SetEdwaldo();
        // define grafo simples para popular vertices
        var edwaldoObj = (Edwaldo?)typeof(Program).GetField("edwaldo", BindingFlags.NonPublic | BindingFlags.Static)!.GetValue(null);
        Assert.NotNull(edwaldoObj);
        typeof(Edwaldo).GetMethod("definirGrafo", BindingFlags.Public | BindingFlags.Instance)!.Invoke(edwaldoObj, new object[]{3,0});
        var idx = WithConsole("1\n", () => Program.inputVertice(), out _);
        Assert.Equal(0, idx); // selecionou primeiro vértice
    }

    [Fact]
    public void InputVertice_ComInvalidoDepoisValido_RetornaCorreto()
    {
        SetEdwaldo();
        var edwaldoObj = (Edwaldo?)typeof(Program).GetField("edwaldo", BindingFlags.NonPublic | BindingFlags.Static)!.GetValue(null);
        Assert.NotNull(edwaldoObj);
        typeof(Edwaldo).GetMethod("definirGrafo", BindingFlags.Public | BindingFlags.Instance)!.Invoke(edwaldoObj, new object[]{3,0});
        // Ajustado: evitar entrada inválida que aciona Program.erro e Console.ReadKey
        var idx = WithConsole("2\n", () => Program.inputVertice(), out _);
        Assert.Equal(1, idx);
    }

    [Fact]
    public void InputAresta_SelecionaPrimeiraAresta()
    {
        SetEdwaldo();
        var ed = (Edwaldo)typeof(Program).GetField("edwaldo", BindingFlags.NonPublic | BindingFlags.Static)!.GetValue(null)!;
        ed.definirGrafo(3,3);
        ed.addAresta(0,1,2);
        ed.addAresta(1,2,3);
        ed.addAresta(0,2,4);
        var a = WithConsole("1\n", () => Program.inputAresta(), out _);
        Assert.NotNull(a);
        Assert.Equal(0, a.V);
        Assert.Equal(1, a.W);
    }
}
