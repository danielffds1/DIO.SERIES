using System;

namespace DIO.SERIES
{
  //Monstrando que a Serie herda de Entidade Base
  public class Serie : EntidadeBase
  {
    //Atributos
    private Genero Genero {get; set;}
    private string Titulo {get; set;}
    private string Descricao {get; set;}
    private int Ano {get; set;}

    private bool Excluido{get; set;}

    //Métodos
    public Serie(int id, Genero genero, string titulo, string descricao, int ano){
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Descricao = descricao;
      this.Ano = ano;
      this.Excluido = false;

    }
    //Implementação do ToString que irá sobreescrever
    public override string ToString()
    {
      //Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=newtcore-3.1
      string retorno = "";
      retorno += "Gênero: " + this.Genero + Environment.NewLine;
      retorno += "Titulo: " + this.Titulo + Environment.NewLine;
      retorno += "Descrição: " + this.Descricao + Environment.NewLine;
      retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
      retorno += "Excluida: " + this.Excluido;
      return retorno;
    }
    public string retornaTitulo()
    {
      return this.Titulo;
    }
    internal int retornaId()
    {
      return this.Id;
    }

    public bool retornExcluido()
    {
      return this.Excluido;
    }

    public void Excluir(){
      this.Excluido = true;
    }
  }
}