using System;
using System.Collections.Generic;
using DIO.SERIES.Interfaces;
namespace DIO.SERIES.Classes
{
  //Estou falando que está classe implementa um repositorio
  //Mas um repositório de Séries - SERIES é o que substituio o T
  public class SerieRepositorio : IRepositorio<Serie>
  {

    private List<Serie> listaSerie = new List<Serie>();
    public void Atualiza(int id, Serie objeto)
    {
      listaSerie[id] = objeto;
    }

    public void Excluir(int id)
    {
      listaSerie[id].Excluir();
      //Implemento de envio de e-mail
    }

    public void Insere(Serie objeto)
    {
      listaSerie.Add(objeto);
    }

    public List<Serie> Lista()
    {
      return listaSerie;
    }

    public int ProximoId()
    {
      return listaSerie.Count;
    }

    public Serie RetornaPorId(int id)
    {
      return listaSerie[id];
    }
  }
}