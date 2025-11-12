namespace Fiap.BlazorCleanArch.Dominio.Excecoes;

public class TamanhoDeAtributoInvalidoExcecao(string nomeAtributo, int tamanhoMinimo, int tamanhoMaximo)
    : Exception($"O atributo '{nomeAtributo}' deve ter entre {tamanhoMinimo} e {tamanhoMaximo} caracteres."){ }
