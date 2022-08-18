namespace System.Collections;

public class OffsetPaginationTests {
    [Fact]
    public void OffsetPagination_Default_Passes() {
        var subject = OffsetPagination.Default();

        subject.Index.Should().Be(0);
        subject.Size.Should().Be(Pagination.DefaultPageSize);
        subject.LastIndex.Should().Be((OffsetPagination.MaxCount / Pagination.DefaultPageSize) - 1);
    }

    [Fact]
    public void OffsetPagination_WithDefaults_Passes() {
        var subject = new OffsetPagination();

        subject.Index.Should().Be(0);
        subject.Size.Should().Be(Pagination.DefaultPageSize);
        subject.LastIndex.Should().Be((OffsetPagination.MaxCount / Pagination.DefaultPageSize) - 1);
        Pagination.MinSize.Should().Be(1);
        Pagination.MaxSize.Should().Be(1_000);
        OffsetPagination.MaxIndex.Should().Be(999_999_999);
        OffsetPagination.MaxCount.Should().Be(1_000_000_000);

        Pagination.DefaultPageSize.Should().Be(20);
    }

    [Fact]
    public void OffsetPagination_WithTotalCount_Passes() {
        var subject = new OffsetPagination(totalCount: 100);

        subject.LastIndex.Should().Be((100 / Pagination.DefaultPageSize) - 1);
    }

    [Fact]
    public void Address_OffsetPagination_WithZeroCount_Passes() {
        var subject = new OffsetPagination(totalCount: 0);

        subject.LastIndex.Should().Be(0);
    }

    [Fact]
    public void Address_OffsetPagination_WithSize_Passes() {
        const uint newSize = 37U;
        var subject = new OffsetPagination(size: newSize);

        subject.Size.Should().Be(newSize);
    }

    [Fact]
    public void Address_OffsetPagination_WithSizeGreaterThanMaxSize_Passes() {
        var subject = new OffsetPagination(size: Pagination.MaxSize + 1);

        subject.Size.Should().Be(Pagination.MaxSize);
    }

    [Fact]
    public void Address_OffsetPagination_WithIndexGreaterThanLastIndex_Passes() {
        var lastIndex = (100 / Pagination.DefaultPageSize) - 1;
        var subject = new OffsetPagination(lastIndex + 1, totalCount: 100);

        subject.Index.Should().Be(lastIndex);
        subject.Size.Should().Be(Pagination.DefaultPageSize);
        subject.LastIndex.Should().Be((100 / Pagination.DefaultPageSize) - 1);
    }

    [Fact]
    public void Address_OffsetPagination_WithIndexGreaterThanMaxIndex_Passes() {
        var subject = new OffsetPagination(OffsetPagination.MaxIndex + 1, 1);

        subject.Index.Should().Be(OffsetPagination.MaxIndex);
        subject.Size.Should().Be(1);
        subject.LastIndex.Should().Be(OffsetPagination.MaxIndex);
    }
}