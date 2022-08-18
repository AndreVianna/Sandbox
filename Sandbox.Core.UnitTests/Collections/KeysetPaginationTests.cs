namespace System.Collections;

using static PaginationDirection;

public class KeysetPaginationTests {
    [Fact]
    public void KeysetPagination_Default_Passes() {
        var subject = KeysetPagination.Default();

        subject.Direction.Should().Be(Forward);
        subject.Key.Should().BeNull();
        subject.Size.Should().Be(Pagination.DefaultPageSize);
    }

    [Fact]
    public void KeysetPagination_WithDefaults_Passes() {
        var subject = new KeysetPagination();

        subject.Direction.Should().Be(Forward);
        subject.Key.Should().BeNull();
        subject.Size.Should().Be(Pagination.DefaultPageSize);
    }

    [Fact]
    public void KeysetPagination_WithKeyAndDirection_Passes() {
        var subject = new KeysetPagination(42, Backward);

        subject.Direction.Should().Be(Backward);
        subject.Key.Should().Be(42);
        subject.Size.Should().Be(Pagination.DefaultPageSize);
    }

    [Fact]
    public void Address_KeysetPagination_WithSize_Passes() {
        const uint newSize = 37U;
        var subject = new KeysetPagination(size: newSize);

        subject.Size.Should().Be(newSize);
    }

    [Fact]
    public void Address_KeysetPagination_WithSizeGreaterThanMaxSize_Passes() {
        var subject = new KeysetPagination(size: Pagination.MaxSize + 1);

        subject.Size.Should().Be(Pagination.MaxSize);
    }
}