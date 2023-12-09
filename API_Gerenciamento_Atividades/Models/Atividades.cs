using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Gerenciamento_Atividades.Models
{
    public class Atividades
    {
        // cada um desses atributos equivale uma coluna no banco de dados
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateOnly DataCriacao { get; set; }
        public string Status { get; set; }
    }
}
