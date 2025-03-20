public class Sample 
{
    [Required(ErrorMessage = "請填寫代號")]
    [ByteLength(10, ErrorMessage = "代號字數過長")]
    public string? Number { get; set; }
  
    [Required(ErrorMessage = "請填寫名稱")]
    [ByteLength(20, ErrorMessage = "名稱字數過長")]
    public string? Name { get; set; }
}
