using System;

namespace ProjAtividadelUnitTest.Api.Models
{
    public class Atividade
    {        
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }  
        public virtual Responsavel responsavel { get; set; }    


    }
}