namespace System.IO;

[ExcludeFromCodeCoverage(Justification = "Testing the system.")]
// ReSharper disable once UnusedType.Global
public sealed class SystemDirectoryHandler : IDirectoryHandler {
    public DirectoryInfo CreateDirectory(string path) => Directory.CreateDirectory(path);
    public FileSystemInfo CreateSymbolicLink(string path, string pathToTarget) => Directory.CreateSymbolicLink(path, pathToTarget);
    public void Delete(string path) => Directory.Delete(path);
    public void Delete(string path, bool recursive) => Directory.Delete(path, recursive);
    public IEnumerable<string> EnumerateDirectories(string path) => Directory.EnumerateDirectories(path);
    public IEnumerable<string> EnumerateDirectories(string path, string searchPattern) => Directory.EnumerateDirectories(path, searchPattern);
    public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions) => Directory.EnumerateDirectories(path, searchPattern, enumerationOptions);
    public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption) => Directory.EnumerateDirectories(path, searchPattern, searchOption);
    public IEnumerable<string> EnumerateFiles(string path) => Directory.EnumerateFiles(path);
    public IEnumerable<string> EnumerateFiles(string path, string searchPattern) => Directory.EnumerateFiles(path, searchPattern);
    public IEnumerable<string> EnumerateFiles(string path, string searchPattern, EnumerationOptions enumerationOptions) => Directory.EnumerateFiles(path, searchPattern, enumerationOptions);
    public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption) => Directory.EnumerateFiles(path, searchPattern, searchOption);
    public IEnumerable<string> EnumerateFileSystemEntries(string path) => Directory.EnumerateFileSystemEntries(path);
    public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern) => Directory.EnumerateFileSystemEntries(path, searchPattern);
    public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions) => Directory.EnumerateFileSystemEntries(path, searchPattern, enumerationOptions);
    public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption) => Directory.EnumerateFileSystemEntries(path, searchPattern, searchOption);
    public bool Exists([NotNullWhen(true)] string? path) => Directory.Exists(path);
    public DateTime GetCreationTime(string path) => Directory.GetCreationTime(path);
    public DateTime GetCreationTimeUtc(string path) => Directory.GetCreationTimeUtc(path);
    public string GetCurrentDirectory() => Directory.GetCurrentDirectory();
    public string[] GetDirectories(string path) => Directory.GetDirectories(path);
    public string[] GetDirectories(string path, string searchPattern) => Directory.GetDirectories(path, searchPattern);
    public string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions) => Directory.GetDirectories(path, searchPattern, enumerationOptions);
    public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption) => Directory.GetDirectories(path, searchPattern, searchOption);
    public string GetDirectoryRoot(string path) => Directory.GetDirectoryRoot(path);
    public string[] GetFiles(string path) => Directory.GetFiles(path);
    public string[] GetFiles(string path, string searchPattern) => Directory.GetFiles(path, searchPattern);
    public string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions) => Directory.GetFiles(path, searchPattern, enumerationOptions);
    public string[] GetFiles(string path, string searchPattern, SearchOption searchOption) => Directory.GetFiles(path, searchPattern, searchOption);
    public string[] GetFileSystemEntries(string path) => Directory.GetFileSystemEntries(path);
    public string[] GetFileSystemEntries(string path, string searchPattern) => Directory.GetFileSystemEntries(path, searchPattern);
    public string[] GetFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions) => Directory.GetFileSystemEntries(path, searchPattern, enumerationOptions);
    public string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption) => Directory.GetFileSystemEntries(path, searchPattern, searchOption);
    public DateTime GetLastAccessTime(string path) => Directory.GetLastAccessTime(path);
    public DateTime GetLastAccessTimeUtc(string path) => Directory.GetLastAccessTimeUtc(path);
    public DateTime GetLastWriteTime(string path) => Directory.GetLastWriteTime(path);
    public DateTime GetLastWriteTimeUtc(string path) => Directory.GetLastWriteTimeUtc(path);
    public string[] GetLogicalDrives() => Directory.GetLogicalDrives();
    public DirectoryInfo? GetParent(string path) => Directory.GetParent(path);
    public void Move(string sourceDirName, string destDirName) => Directory.Move(sourceDirName, destDirName);
    public FileSystemInfo? ResolveLinkTarget(string linkPath, bool returnFinalTarget) => Directory.ResolveLinkTarget(linkPath, returnFinalTarget);
    public void SetCreationTime(string path, DateTime creationTime) => Directory.SetCreationTime(path, creationTime);
    public void SetCreationTimeUtc(string path, DateTime creationTimeUtc) => Directory.SetCreationTimeUtc(path, creationTimeUtc);
    public void SetCurrentDirectory(string path) => Directory.SetCurrentDirectory(path);
    public void SetLastAccessTime(string path, DateTime lastAccessTime) => Directory.SetLastAccessTime(path, lastAccessTime);
    public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc) => Directory.SetLastAccessTimeUtc(path, lastAccessTimeUtc);
    public void SetLastWriteTime(string path, DateTime lastWriteTime) => Directory.SetLastWriteTime(path, lastWriteTime);
    public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc) => Directory.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
}