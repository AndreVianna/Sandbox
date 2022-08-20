namespace System.Linq;

public class QueryableExtensionsTests {
    private record Test(string Name, ICollection<string> Items);
    private readonly Test[] _subject = { new("Alice", new[] { "A", "B", "C" }), new("Bob", new[] { "1", "2", "3", "4" }), new("Charlie", new[] { "X", "Y" }) };

    [Fact]
    public void QueryableExtensions_Project_ReturnsProjectedCollection() {
        var result = _subject.AsQueryable().Project(x => x.Name).ToArray();

        result.Should().BeEquivalentTo("Alice", "Bob", "Charlie");
    }

    [Fact]
    public void QueryableExtensions_Project_WithIndex_ReturnsProjectedCollection() {
        var result = _subject.AsQueryable().Project((x, i) => $"{x.Name} @ {i}").ToArray();

        result.Should().BeEquivalentTo("Alice @ 0", "Bob @ 1", "Charlie @ 2");
    }

    [Fact]
    public void QueryableExtensions_Expand_ReturnsExpandedCollection() {
        var result = _subject.AsQueryable().Expand(x => x.Items).ToArray();

        result.Should().BeEquivalentTo("A", "B", "C", "1", "2", "3", "4", "X", "Y");
    }

    [Fact]
    public void QueryableExtensions_Expand_WithIndex_ReturnsExpandedCollection() {
        var result = _subject.AsQueryable().Expand((x, i) => x.Items.Project((m, j) => $"{i}.{j}:{m}")).ToArray();

        result.Should().BeEquivalentTo("0.0:A", "0.1:B", "0.2:C", "1.0:1", "1.1:2", "1.2:3", "1.3:4", "2.0:X", "2.1:Y");
    }

    [Fact]
    public void QueryableExtensions_Expand_WithProjection_ReturnsExpandedCollection() {
        var result = _subject.AsQueryable().Expand(x => x.Items, (c, i) => $"{c.Name} has {i}").ToArray();

        result.Should().BeEquivalentTo("Alice has A", "Alice has B", "Alice has C", "Bob has 1", "Bob has 2", "Bob has 3", "Bob has 4", "Charlie has X", "Charlie has Y");
    }

    [Fact]
    public void QueryableExtensions_Expand_WithIndexAndProjection_ReturnsExpandedCollection() {
        var result = _subject.AsQueryable().Expand((x, i) => x.Items.Project((m, j) => $"{m} @ {i}.{j}"), (c, i) => $"{c.Name} has {i}").ToArray();

        result.Should().BeEquivalentTo("Alice has A @ 0.0", "Alice has B @ 0.1", "Alice has C @ 0.2", "Bob has 1 @ 1.0", "Bob has 2 @ 1.1", "Bob has 3 @ 1.2", "Bob has 4 @ 1.3", "Charlie has X @ 2.0", "Charlie has Y @ 2.1");
    }
}