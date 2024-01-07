namespace SignalRWebUI.Dtos.BasketDtos;

public class ResultBasketDto
{
    public int BasketId { get; set; }

    public decimal Price { get; set; }
    public int Count { get; set; }
    public decimal TotalPrice { get; set; }
    public int ProductId { get; set; }
    public int MenuTableId { get; set; }
    public string ProductName { get; set; }
}
