namespace Olbrasoft.SemiStaticContent;
public interface ISemiStaticContentStore
{
    public Task<string> GetSource(string key);
}
