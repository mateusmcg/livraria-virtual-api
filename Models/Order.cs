using System;
using System.Collections.Generic;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string UserName { get; set; }
    public string UserAddress { get; set; }
    public List<Cart> Items { get; set; }
}