namespace System.IO;

public class DummyDirectoryHandler : IDirectoryHandler {
    public virtual DirectoryInfo CreateDirectory(string path) => throw new NotImplementedException();
    public virtual FileSystemInfo CreateSymbolicLink(string path, string pathToTarget) => throw new NotImplementedException();
    public virtual void Delete(string path) => throw new NotImplementedException();
    public virtual void Delete(string path, bool recursive) => throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateDirectories(string path) => throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateDirectories(string path, string searchPattern) => throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions) => throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption) => throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateFiles(string path) =>throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateFiles(string path, string searchPattern) =>throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateFiles(string path, string searchPattern, EnumerationOptions enumerationOptions) =>throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption) =>throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateFileSystemEntries(string path) =>throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern) =>throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions) =>throw new NotImplementedException();
    public virtual IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption) =>throw new NotImplementedException();
    public virtual bool Exists(string? path) =>throw new NotImplementedException();
    public virtual DateTime GetCreationTime(string path) =>throw new NotImplementedException();
    public virtual DateTime GetCreationTimeUtc(string path) =>throw new NotImplementedException();
    public virtual string GetCurrentDirectory() =>throw new NotImplementedException();
    public virtual string[] GetDirectories(string path) =>throw new NotImplementedException();
    public virtual string[] GetDirectories(string path, string searchPattern) =>throw new NotImplementedException();
    public virtual string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions) =>throw new NotImplementedException();
    public virtual string[] GetDirectories(string path, string searchPattern, SearchOption searchOption) =>throw new NotImplementedException();
    public virtual string GetDirectoryRoot(string path) =>throw new NotImplementedException();
    public virtual string[] GetFiles(string path) =>throw new NotImplementedException();
    public virtual string[] GetFiles(string path, string searchPattern) =>throw new NotImplementedException();
    public virtual string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions) =>throw new NotImplementedException();
    public virtual string[] GetFiles(string path, string searchPattern, SearchOption searchOption) =>throw new NotImplementedException();
    public virtual string[] GetFileSystemEntries(string path) =>throw new NotImplementedException();
    public virtual string[] GetFileSystemEntries(string path, string searchPattern) =>throw new NotImplementedException();
    public virtual string[] GetFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions) =>throw new NotImplementedException();
    public virtual string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption) =>throw new NotImplementedException();
    public virtual DateTime GetLastAccessTime(string path) =>throw new NotImplementedException();
    public virtual DateTime GetLastAccessTimeUtc(string path) =>throw new NotImplementedException();
    public virtual DateTime GetLastWriteTime(string path) =>throw new NotImplementedException();
    public virtual DateTime GetLastWriteTimeUtc(string path) =>throw new NotImplementedException();
    public virtual string[] GetLogicalDrives() =>throw new NotImplementedException();
    // ReSharper disable once ReturnTypeCanBeNotNullable
    public virtual DirectoryInfo? GetParent(string path) =>throw new NotImplementedException();
    public virtual void Move(string sourceDirName, string destDirName) =>throw new NotImplementedException();
    // ReSharper disable once ReturnTypeCanBeNotNullable
    public virtual FileSystemInfo? ResolveLinkTarget(string linkPath, bool returnFinalTarget) =>throw new NotImplementedException();
    public virtual void SetCreationTime(string path, DateTime creationTime) =>throw new NotImplementedException();
    public virtual void SetCreationTimeUtc(string path, DateTime creationTimeUtc) =>throw new NotImplementedException();
    public virtual void SetCurrentDirectory(string path) =>throw new NotImplementedException();
    public virtual void SetLastAccessTime(string path, DateTime lastAccessTime) =>throw new NotImplementedException();
    public virtual void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc) =>throw new NotImplementedException();
    public virtual void SetLastWriteTime(string path, DateTime lastWriteTime) =>throw new NotImplementedException();
    public virtual void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc) =>throw new NotImplementedException();
}