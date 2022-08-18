namespace System.Collections;

public class PaginationTests {
    [Fact]
    public void Pagination_Configuration_Passes() {
        var oldValue = Pagination.DefaultPageSize;
        var newValue = Pagination.DefaultPageSize + 10;

        Pagination.Configure(newValue);

        Pagination.DefaultPageSize.Should().Be(newValue);
        Pagination.Configure(oldValue);
    }

    [Fact]
    public void Pagination_Configuration_WithDefaultPageSizeLessThan1_Passes() {
        var oldValue = Pagination.DefaultPageSize;

        Pagination.Configure(0);

        Pagination.DefaultPageSize.Should().Be(oldValue);
    }

    [Fact]
    public void Pagination_Configuration_WithDefaultPageSizeGreaterThanMaxValue_Passes() {
        var oldValue = Pagination.DefaultPageSize;

        Pagination.Configure(Pagination.MaxSize + 10);

        Pagination.DefaultPageSize.Should().Be(Pagination.MaxSize);

        Pagination.Configure(oldValue);
    }
}