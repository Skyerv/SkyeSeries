namespace DIO.Series {
    public class Serie : EntidadeBase {
        
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano){
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public string retornarTitulo(){
            return this.Titulo;
        }

        internal int retornarId(){
            return this.Id;
        }

        public void excluir(){
            this.Excluido = true;
        }

        public void MostraSerie(){
            Console.WriteLine("Titulo: {0}", this.Titulo);
            Console.WriteLine("Genero: {0}", this.Genero);
            Console.WriteLine("Ano: {0}", this.Ano);
            Console.WriteLine("Descrição: {0}", this.Descricao);
        }
    }
}