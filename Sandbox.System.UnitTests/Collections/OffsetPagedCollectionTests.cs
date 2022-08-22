namespace System.Collections;

using static Pagination;

public class OffsetPagedCollectionTests {
    [Fact]
    public void OffsetPagedCollection_Empty_Passes() {
        var subject = OffsetPagedCollection.Empty<int>();

        subject.PageSize.Should().Be(DefaultPageSize);
        subject.PageIndex.Should().Be(0);
        subject.TotalCount.Should().Be(0);
        subject.Items.Count.Should().Be(0);
    }

    [Fact]
    public void OffsetPagedCollectionOfT_Schema_Checks() {
        var subject = new OffsetPagedCollection<int> {
            PageIndex = 0,
            PageSize = 5,
            TotalCount = 12,
            Items = new[] { 1, 2, 3, 4, 5 },
        };

        subject.PageSize.Should().Be(5);
        subject.PageIndex.Should().Be(0);
        subject.TotalCount.Should().Be(12);
        subject.Items.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
    }
}