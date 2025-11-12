namespace Fiap.BlazorCleanArch.Dominio.Excecoes;

public class AtributoInvalidoExcecao(string nomeAtributo)
    : Exception($"O atributo '{nomeAtributo}' possui um valor inválido."){}
