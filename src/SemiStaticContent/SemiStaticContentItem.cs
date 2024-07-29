using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.SemiStaticContent;

public class SemiStaticContentItem
{

    [Key, MaxLength(20)]
    public string Key { get; set; } = string.Empty;

    [Required, DataType(DataType.MultilineText)]
    public string Text { get; set; } = string.Empty;
}