using System.Runtime.Versioning;
using Microsoft.Win32.SafeHandles;

namespace System.IO;

[ExcludeFromCodeCoverage(Justification = "Testing the system.")]
// ReSharper disable once UnusedType.Global
public sealed class SystemFileHandler : IFileHandler {
    public void AppendAllLines(string path, IEnumerable<string> contents) => File.AppendAllLines(path, contents);
    public void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding) => File.AppendAllLines(path, contents, encoding);
    public Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default) => File.AppendAllLinesAsync(path, contents, cancellationToken);
    public Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default) => File.AppendAllLinesAsync(path, contents, encoding, cancellationToken);
    public void AppendAllText(string path, string? contents) => File.AppendAllText(path, contents);
    public void AppendAllText(string path, string? contents, Encoding encoding) => File.AppendAllText(path, contents, encoding);
    public Task AppendAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default) => File.AppendAllTextAsync(path, contents, cancellationToken);
    public Task AppendAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default) => File.AppendAllTextAsync(path, contents, encoding, cancellationToken);
    public StreamWriter AppendText(string path) => File.AppendText(path);
    public void Copy(string sourceFileName, string destFileName) => File.Copy(sourceFileName, destFileName);
    public void Copy(string sourceFileName, string destFileName, bool overwrite) => File.Copy(sourceFileName, destFileName, overwrite);
    public FileStream Create(string path) => File.Create(path);
    public FileStream Create(string path, int bufferSize) => File.Create(path, bufferSize);
    public FileStream Create(string path, int bufferSize, FileOptions options) => File.Create(path, bufferSize, options);
    public FileSystemInfo CreateSymbolicLink(string path, string pathToTarget) => File.CreateSymbolicLink(path, pathToTarget);
    public StreamWriter CreateText(string path) => File.CreateText(path);
    [SupportedOSPlatform("windows")]
    public void Decrypt(string path) => File.Decrypt(path);
    public void Delete(string path) => File.Delete(path);
    [SupportedOSPlatform("windows")]
    public void Encrypt(string path) => File.Encrypt(path);
    public bool Exists([NotNullWhen(true)] string? path) => File.Exists(path);
    public FileAttributes GetAttributes(string path) => File.GetAttributes(path);
    public DateTime GetCreationTime(string path) => File.GetCreationTime(path);
    public DateTime GetCreationTimeUtc(string path) => File.GetCreationTimeUtc(path);
    public DateTime GetLastAccessTime(string path) => File.GetLastAccessTime(path);
    public DateTime GetLastAccessTimeUtc(string path) => File.GetLastAccessTimeUtc(path);
    public DateTime GetLastWriteTime(string path) => File.GetLastWriteTime(path);
    public DateTime GetLastWriteTimeUtc(string path) => File.GetLastWriteTimeUtc(path);
    public void Move(string sourceFileName, string destFileName) => File.Move(sourceFileName, destFileName);
    public void Move(string sourceFileName, string destFileName, bool overwrite) => File.Move(sourceFileName, destFileName, overwrite);
    public FileStream Open(string path, FileStreamOptions options) => File.Open(path, options);
    public FileStream Open(string path, FileMode mode) => File.Open(path, mode);
    public FileStream Open(string path, FileMode mode, FileAccess access) => File.Open(path, mode, access);
    public FileStream Open(string path, FileMode mode, FileAccess access, FileShare share) => File.Open(path, mode, access, share);
    public SafeFileHandle OpenHandle(string path, FileMode mode = FileMode.Open, FileAccess access = FileAccess.Read, FileShare share = FileShare.Read, FileOptions options = FileOptions.None, long preAllocationSize = 0)
        => File.OpenHandle(path, mode, access, share, options, preAllocationSize);
    public FileStream OpenRead(string path) => File.OpenRead(path);
    public StreamReader OpenText(string path) => File.OpenText(path);
    public FileStream OpenWrite(string path) => File.OpenWrite(path);
    public byte[] ReadAllBytes(string path) => File.ReadAllBytes(path);
    public Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default) => File.ReadAllBytesAsync(path, cancellationToken);
    public string[] ReadAllLines(string path) => File.ReadAllLines(path);
    public string[] ReadAllLines(string path, Encoding encoding) => File.ReadAllLines(path, encoding);
    public Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default) => File.ReadAllLinesAsync(path, cancellationToken);
    public Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default) => File.ReadAllLinesAsync(path, encoding, cancellationToken);
    public string ReadAllText(string path) => File.ReadAllText(path);
    public string ReadAllText(string path, Encoding encoding) => File.ReadAllText(path, encoding);
    public Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default) => File.ReadAllTextAsync(path, cancellationToken);
    public Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default) => File.ReadAllTextAsync(path, encoding, cancellationToken);
    public IEnumerable<string> ReadLines(string path) => File.ReadLines(path);
    public IEnumerable<string> ReadLines(string path, Encoding encoding) => File.ReadLines(path, encoding);
    public void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName) => File.Replace(sourceFileName, destinationFileName, destinationBackupFileName);
    public void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors) => File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors);
    public FileSystemInfo? ResolveLinkTarget(string linkPath, bool returnFinalTarget) => File.ResolveLinkTarget(linkPath, returnFinalTarget);
    public void SetAttributes(string path, FileAttributes fileAttributes) => File.SetAttributes(path, fileAttributes);
    public void SetCreationTime(string path, DateTime creationTime) => File.SetCreationTime(path, creationTime);
    public void SetCreationTimeUtc(string path, DateTime creationTimeUtc) => File.SetCreationTimeUtc(path, creationTimeUtc);
    public void SetLastAccessTime(string path, DateTime lastAccessTime) => File.SetLastAccessTime(path, lastAccessTime);
    public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc) => File.SetLastAccessTimeUtc(path, lastAccessTimeUtc);
    public void SetLastWriteTime(string path, DateTime lastWriteTime) => File.SetLastWriteTime(path, lastWriteTime);
    public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc) => File.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
    public void WriteAllBytes(string path, byte[] bytes) => File.WriteAllBytes(path, bytes);
    public Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default) => File.WriteAllBytesAsync(path, bytes, cancellationToken);
    public void WriteAllLines(string path, string[] contents) => File.WriteAllLines(path, contents);
    public void WriteAllLines(string path, string[] contents, Encoding encoding) => File.WriteAllLines(path, contents, encoding);
    public void WriteAllLines(string path, IEnumerable<string> contents) => File.WriteAllLines(path, contents);
    public void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding) => File.WriteAllLines(path, contents, encoding);
    public Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default) => File.WriteAllLinesAsync(path, contents, encoding, cancellationToken);
    public Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default) => File.WriteAllLinesAsync(path, contents, cancellationToken);
    public void WriteAllText(string path, string? contents) => File.WriteAllText(path, contents);
    public void WriteAllText(string path, string? contents, Encoding encoding) => File.WriteAllText(path, contents, encoding);
    public Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default) => File.WriteAllTextAsync(path, contents, cancellationToken);
    public Task WriteAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default) => File.WriteAllTextAsync(path, contents, encoding, cancellationToken);
}