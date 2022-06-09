using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Jugador
    {
        public string Nombre;
        public int Puntaje;

        public Jugador()
        {
        }
        
        public Jugador(string nombre, int puntaje)
        {
            Nombre = nombre;
            Puntaje = puntaje;
        }

        public void AsignarNombre(string nombre)
        {
            Nombre = nombre;
        }

        public string ObtenerNombre()
        {
            return Nombre;
        }

        public void AsignarPuntaje(int puntaje)
        {
            Puntaje = puntaje;
        }
        
        public int ObtenerPuntaje()
        {
            return Puntaje;
        }
    }
}
