using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class  RedeSocialDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "o Campo {0} é Obrigatorio")]
        public string URL { get; set; }
    }
}