namespace Fiap.BlazorCleanArch.Dominio.Excecoes;

public class AtributoObrigatorioExcecao(string nomeAtributo) 
    : Exception($"O atributo '{nomeAtributo}' é obrigatório e não pode ser vazio.") { }
