namespace System.Collections;

using static Pagination;

public class KeysetPagedCollectionTests {
    [Fact]
    public void KeysetPagedCollection_Empty_Passes() {
        var subject = KeysetPagedCollection.Empty<int>();

        subject.PageSize.Should().Be(DefaultPageSize);
        subject.Items.Count.Should().Be(0);
    }

    [Fact]
    public void KeysetPagedCollectionOfT_Schema_Checks() {
        var subject = new KeysetPagedCollection<int> {
            PageSize = 10,
            Items = new[] { 1, 2, 3, 4, 5 },
        };

        subject.PageSize.Should().Be(10);
        subject.Items.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
    }
}