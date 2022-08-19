namespace System.IO;

public class DummyDirectoryHandlerTests {
    [Fact]
    public void DummyDirectoryHandler_AllMethods_Throw() {
        var subject = new DummyDirectoryHandler();

        ((Action)(() => subject.CreateDirectory(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.CreateSymbolicLink("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Delete(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Delete("", false))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateDirectories(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateDirectories("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateDirectories("", "", new EnumerationOptions()))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateDirectories("", "", SearchOption.AllDirectories))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateFiles(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateFiles("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateFiles("", "", new EnumerationOptions()))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateFiles("", "", SearchOption.AllDirectories))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateFileSystemEntries(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateFileSystemEntries("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateFileSystemEntries("", "", new EnumerationOptions()))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.EnumerateFileSystemEntries("", "", SearchOption.AllDirectories))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Exists(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetCreationTime(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetCreationTimeUtc(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetCurrentDirectory())).Should().Throw<NotImplementedException>();;
        ((Action)(() => subject.GetDirectories(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetDirectories("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetDirectories("", "", new EnumerationOptions()))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetDirectories("", "", SearchOption.AllDirectories))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetDirectoryRoot(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetFiles(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetFiles("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetFiles("", "", new EnumerationOptions()))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetFiles("", "", SearchOption.AllDirectories))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetFileSystemEntries(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetFileSystemEntries("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetFileSystemEntries("", "", new EnumerationOptions()))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetFileSystemEntries("", "", SearchOption.AllDirectories))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetLastAccessTime(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetLastAccessTimeUtc(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetLastWriteTime(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetLastWriteTimeUtc(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetLogicalDrives())).Should().Throw<NotImplementedException>();;
        ((Action)(() => subject.GetParent(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Move("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.ResolveLinkTarget("", false))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetCreationTime("", DateTime.Now))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetCreationTimeUtc("", DateTime.Now))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetCurrentDirectory(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetLastAccessTime("", DateTime.Now))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetLastAccessTimeUtc("", DateTime.Now))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetLastWriteTime("", DateTime.Now))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetLastWriteTimeUtc("", DateTime.Now))).Should().Throw<NotImplementedException>();
    }
}