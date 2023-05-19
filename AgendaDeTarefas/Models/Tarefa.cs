using System.ComponentModel.DataAnnotations;

namespace AgendaDeTarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        [Required(ErrorMessage = "{0} é obragatório")]
        [StringLength(50, ErrorMessage ="Use menos caracteres")]
        public string Nome { get; set; }
        public string Data { get; set; }

        [Required(ErrorMessage ="{0} é obrigatório")]
        [DataType(DataType.Time)]
        public string Horario { get; set; }

        public Tarefa()
        {

        }
    }
}
