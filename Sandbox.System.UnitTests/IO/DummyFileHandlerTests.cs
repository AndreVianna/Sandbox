namespace System.IO;

public class DummyFileHandlerTests {
    private sealed class TestFileHandler : DummyFileHandler { }

    [Fact]
    public void DummyFileHandler_AllMethods_Throw() {
        var subject = new TestFileHandler();

        ((Action)(() => subject.AppendAllLines("", Array.Empty<string>()))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.AppendAllLines("", Array.Empty<string>(), Encoding.UTF8))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.AppendAllText("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.AppendAllText("", "", Encoding.UTF8))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.AppendText(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Copy("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Copy("", "", false))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Create(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Create("", 0))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Create("", 0, FileOptions.None))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.CreateSymbolicLink("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.CreateText(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Decrypt(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Delete(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Encrypt(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Exists(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetAttributes(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetCreationTime(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetCreationTimeUtc(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetLastAccessTime(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetLastAccessTimeUtc(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetLastWriteTime(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.GetLastWriteTimeUtc(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Move("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Move("", "", false))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Open("", FileMode.Open))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Open("", FileMode.Open, FileAccess.ReadWrite))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Open("", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Open("", new FileStreamOptions()))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.OpenHandle(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.OpenRead(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.OpenText(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.OpenWrite(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.ReadAllBytes(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.ReadAllLines(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.ReadAllLines("", Encoding.UTF8))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.ReadAllText("", Encoding.UTF8))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.ReadAllText(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.ReadLines(""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.ReadLines("", Encoding.UTF8))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Replace("", "", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.Replace("", "", "", false))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.ResolveLinkTarget("", false))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetAttributes("", FileAttributes.Normal))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetCreationTime("", DateTime.Now))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetCreationTimeUtc("", DateTime.Now))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetLastAccessTime("", DateTime.Now))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetLastAccessTimeUtc("", DateTime.Now))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetLastWriteTime("", DateTime.Now))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.SetLastWriteTimeUtc("", DateTime.Now))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.WriteAllBytes("", Array.Empty<byte>()))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.WriteAllLines("", Array.Empty<string>(), Encoding.UTF8))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.WriteAllLines("", Array.Empty<string>()))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.WriteAllLines("", new List<string>(), Encoding.UTF8))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.WriteAllLines("", new List<string>()))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.WriteAllText("", ""))).Should().Throw<NotImplementedException>();
        ((Action)(() => subject.WriteAllText("", "", Encoding.UTF8))).Should().Throw<NotImplementedException>();
    }

    [Fact]
    public async Task DummyFile_AllAsyncMethods_Throw() {
        var subject = new TestFileHandler();

        await ((Func<Task>)(() => subject.AppendAllLinesAsync("", Array.Empty<string>(), Encoding.UTF8))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.AppendAllLinesAsync("", Array.Empty<string>()))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.AppendAllTextAsync("", "", Encoding.UTF8))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.AppendAllTextAsync("", ""))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.ReadAllBytesAsync(""))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.ReadAllLinesAsync("", Encoding.UTF8))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.ReadAllLinesAsync(""))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.ReadAllTextAsync("", Encoding.UTF8))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.ReadAllTextAsync(""))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.WriteAllBytesAsync("", Array.Empty<byte>()))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.WriteAllLinesAsync("", Array.Empty<string>(), Encoding.UTF8))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.WriteAllLinesAsync("", Array.Empty<string>()))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.WriteAllTextAsync("", "", Encoding.UTF8))).Should().ThrowAsync<NotImplementedException>();
        await ((Func<Task>)(() => subject.WriteAllTextAsync("", ""))).Should().ThrowAsync<NotImplementedException>();
    }
}