namespace SistemaVenda.Dto
{
    public record ProductDto(
        int id,
        string name,
        decimal price,
        int quantity);
}
