namespace Otus.DelegatesHomework;

public class FileFinder
{
    private bool flag = false;
    
    public event EventHandler<FileArgs>? FileFound;

    public void CancelFinding()
    {
        flag = true;
    }
    
    public void Find(string path)
    {
        foreach (var file in Directory.EnumerateFiles(path))
        {
            if(flag)
                return;
            FileFound?.Invoke(this, new FileArgs
            {
                Name = file.Split(Path.DirectorySeparatorChar).Last()
            });
        }
    }
}