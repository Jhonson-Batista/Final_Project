namespace Contact_list
{
    public class Contacto
    {
        private int _id;
        private string _nombre;
        private string _telefono;
        private string _email;

       
        public Contacto()
        {
            _id = 0;
            _nombre = string.Empty;
            _telefono = string.Empty;
            _email = string.Empty;
        }

 
        public Contacto(int id, string nombre, string telefono, string email)
        {
            _id = id;
            _nombre = nombre;
            _telefono = telefono;
            _email = email;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

       
        public override string ToString()
        {
            return $"[{_id}] {_nombre} | Tel: {_telefono} | Email: {_email}";
        }
    }
}