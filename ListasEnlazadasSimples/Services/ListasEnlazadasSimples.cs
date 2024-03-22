using ListasEnlazadasSimples.DTO;
using System.Collections;

namespace ListasEnlazadasSimples.Services
{
    public class ListasEnlazadasSimples
    {
        public Nodo PrimerNodo { get; set; }
        public Nodo UltimoNodo { get; set; }

        public ListasEnlazadasSimples()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        public bool ListaVacia()
        {
            return PrimerNodo == null;
        }

        public string AgregarNodoAlFinal(Nodo nuevoNodo)
        {
            if (ListaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Liga = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }

            return "Se ha agregado el nodo al final";
        }

        public string AgregarNodoAlInicio(Nodo nuevoNodo)
        {
            if (ListaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Liga = PrimerNodo;
                PrimerNodo = nuevoNodo;

            }

            return "Se ha agregado el nodo al inicio";
        }

        public string AgregarNodoAntesDeDatoX(string datoX, Nodo nuevoNodo)
        {
            if (ListaVacia())
            {
                return "La lista está vacía, no se puede agregar antes de un dato específico.";
            }

            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;

            while (nodoActual != null)
            {
                if (nodoActual.Info.ToString() == datoX)
                {
                    if (nodoAnterior == null)
                    {
                        AgregarNodoAlInicio(nuevoNodo);
                    }
                    else
                    {
                        nuevoNodo.Liga = nodoActual;
                        nodoAnterior.Liga = nuevoNodo;
                    }
                    return "Se ha agregado el nodo antes del dato específico.";
                }
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Liga;
            }
            return "El dato específico no se encontró en la lista.";
        }

        public string AgregarNodoDespuesDeDatoX(string datoX, Nodo nuevoNodo)
        {
            if (ListaVacia())
            {
                return "La lista está vacía, no se puede agregar después de un dato específico.";
            }

            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.Info.ToString() == datoX)
                {
                    nuevoNodo.Liga = nodoActual.Liga;
                    nodoActual.Liga = nuevoNodo;
                    return "Se ha agregado el nodo después del dato específico.";
                }
                nodoActual = nodoActual.Liga;
            }
            return "El dato específico no se encontró en la lista.";
        }

        public string AgregarNodoEnPosicionEspecifica(Nodo nuevoNodo, int ubicacion)
        {
            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;
            int posicion = 1;

            while (nodoActual != null && posicion < ubicacion)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Liga;
                posicion++;
            }

            if (nodoActual != null)
            {
                nuevoNodo.Liga = nodoActual;
                if (nodoAnterior != null)
                {
                    nodoAnterior.Liga = nuevoNodo;
                }
                else
                {
                    PrimerNodo = nuevoNodo;
                }
                return "Se ha agregado el nodo en la ubicación específica.";
            }
            else
            {
                return "La ubicación específica está fuera de rango.";
            }
        }

        public string AgregarNodoAntesDePosicionEspecifica(Nodo nuevoNodo, int ubicacion)
        {
            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;
            int posicion = 1;

            while (nodoActual != null && posicion < ubicacion)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Liga;
                posicion++;
            }

            if (nodoActual != null && nodoAnterior != null)
            {
                nuevoNodo.Liga = nodoActual;
                nodoAnterior.Liga = nuevoNodo;
                return "Se ha agregado el nodo antes de la ubicación específica.";
            }
            else
            {
                return "No se puede agregar antes de la ubicación específica.";
            }
        }

        public string AgregarNodoDespuesDePosicionEspecifica(Nodo nuevoNodo, int posicion)
        {
            if (posicion < 0 || ListaVacia())
            {
                return "No se puede agregar después de una ubicación inválida.";
            }

            Nodo nodoActual = PrimerNodo;
            int pos = 1;

            while (nodoActual != null && pos < posicion)
            {
                nodoActual = nodoActual.Liga;
                pos++;
            }

            if (nodoActual != null)
            {
                nuevoNodo.Liga = nodoActual.Liga;
                nodoActual.Liga = nuevoNodo;
                return "Se ha agregado el nodo después de la ubicación específica.";
            }
            else
            {
                return "No se puede agregar después de la ubicación específica.";
            }
        }

        //public IEnumerator GetEnumerator()
        //{
        //    Nodo nodoAuxiliar = PrimerNodo;

        //    while (nodoAuxiliar != null)
        //    {
        //        yield return nodoAuxiliar;
        //        nodoAuxiliar = nodoAuxiliar.Liga;
        //    }
        //}
    }
}
