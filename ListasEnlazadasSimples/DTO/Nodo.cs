namespace ListasEnlazadasSimples.DTO
{
    public class Nodo
    {
        public object Info { get; set; }
        public Nodo Liga { get; set; }

        public Nodo()
        {
            Info = null;
            Liga = null;
        }

        public Nodo(object info, Nodo liga)
        {
            Info = info;
            Liga = liga;
        }

        public Nodo(object info)
        {
            Info = info;
            Liga = null;
        }

        public override string ToString()
        {
            return $"{Info}";
        }
    }
}