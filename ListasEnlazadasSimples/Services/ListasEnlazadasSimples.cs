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

        public (Nodo, int) BuscarElemento(string dato)
        {
            Nodo nodoActual = PrimerNodo;
            int posicion = 1;

            while (nodoActual != null)
            {
                if (nodoActual.Info.ToString() == dato)
                {
                    return (nodoActual, posicion);
                }
                nodoActual = nodoActual.Liga;
                posicion++;
            }

            return (null, -1);
        }

        public string EliminarNodoInicio()
        {
            if (ListaVacia())
            {
                return "La lista está vacía, no se puede eliminar ningún nodo.";
            }

            if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
                PrimerNodo = PrimerNodo.Liga;
            }

            return "Se ha eliminado el nodo al inicio de la lista.";
        }

        public void OrdenarAscendente()
        {
            bool intercambio;
            do
            {
                intercambio = false;
                Nodo nodoActual = PrimerNodo;
                Nodo nodoSiguiente = PrimerNodo?.Liga;

                while (nodoSiguiente != null)
                {
                    if (string.Compare(nodoActual.Info.ToString(), nodoSiguiente.Info.ToString(), StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        object temp = nodoActual.Info;
                        nodoActual.Info = nodoSiguiente.Info;
                        nodoSiguiente.Info = temp;

                        intercambio = true;
                    }

                    nodoActual = nodoSiguiente;
                    nodoSiguiente = nodoSiguiente.Liga;
                }
            } while (intercambio);
        }

        public void OrdenarDescendente()
        {
            bool intercambio;
            do
            {
                intercambio = false;
                Nodo nodoActual = PrimerNodo;
                Nodo nodoSiguiente = PrimerNodo?.Liga;

                while (nodoSiguiente != null)
                {
                    if (string.Compare(nodoActual.Info.ToString(), nodoSiguiente.Info.ToString(), StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        object temp = nodoActual.Info;
                        nodoActual.Info = nodoSiguiente.Info;
                        nodoSiguiente.Info = temp;

                        intercambio = true;
                    }

                    nodoActual = nodoSiguiente;
                    nodoSiguiente = nodoSiguiente.Liga;
                }
            } while (intercambio);
        }

		public string EliminarEnPosicionEspecifica(int posicion)
		{
			if (ListaVacia())
			{
				return "La lista está vacía, no se puede eliminar ningún nodo.";
			}

			if (posicion <= 0)
			{
				return "La posición específica debe ser mayor que cero.";
			}

			if (posicion == 1)
			{
				return EliminarNodoInicio();
			}

			Nodo nodoActual = PrimerNodo;
			Nodo nodoAnterior = null;
			int posicionActual = 1;

			while (nodoActual != null && posicionActual < posicion)
			{
				nodoAnterior = nodoActual;
				nodoActual = nodoActual.Liga;
				posicionActual++;
			}

			if (nodoActual != null)
			{
				nodoAnterior.Liga = nodoActual.Liga;

				if (nodoActual == UltimoNodo)
				{
					UltimoNodo = nodoAnterior;
				}

				return "Se ha eliminado el nodo en la posición específica.";
			}

			return "La posición específica está fuera de rango.";
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
