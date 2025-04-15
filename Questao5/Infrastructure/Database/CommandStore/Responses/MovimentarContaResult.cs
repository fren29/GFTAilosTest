using Swashbuckle.AspNetCore.Annotations;

namespace Questao5.Infrastructure.Database.CommandStore.Responses;

public class MovimentarContaResult
{
    [SwaggerSchema("Identificador único do movimento registrado.")]
    public Guid IdMovimento { get; set; }
}
