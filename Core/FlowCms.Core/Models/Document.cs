namespace FlowCms.Core.Models;

public abstract class Document
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Content { get; set; }
}

public class Project : Document
{ }