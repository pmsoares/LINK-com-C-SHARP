namespace Cap6CSharp
{
    public class AlunoComContacto : Aluno
    {
        private Contacto _contacto;

        public Contacto Contacto
        {
            get { return _contacto; }
            set { _contacto = value; }
        }
    }
}