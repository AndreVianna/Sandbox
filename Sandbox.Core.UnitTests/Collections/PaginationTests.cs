namespace System.Collections;

public class PaginationTests {
    private readonly object _lockObject = new();

    [Fact]
    public void Pagination_Configuration_Passes() {
        var oldValue = Pagination.DefaultPageSize;
        try {
            var newValue = Pagination.DefaultPageSize + 10;

            Pagination.Configure(newValue);

            Pagination.DefaultPageSize.Should().Be(newValue);
        }
        finally {
            Pagination.Configure(oldValue);
        }
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
        try {
            Pagination.Configure(Pagination.MaxSize + 10);

            Pagination.DefaultPageSize.Should().Be(Pagination.MaxSize);
        }
        finally {
            Pagination.Configure(oldValue);
        }
    }
}