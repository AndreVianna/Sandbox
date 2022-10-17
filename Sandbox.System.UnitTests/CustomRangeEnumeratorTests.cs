namespace System;

public class CustomRangeEnumeratorTests {
    [Fact]
    public void CustomRangeEnumerator_ForEachRange_Loops() {
        var count = 0;
        foreach (var i in 0..10) {
            i.Should().Be(count++);
        }
        count.Should().Be(11);
    }

    [Fact]
    public void CustomRangeEnumerator_ForEachRange_WithoutEnd_Throws() {
        var action = () => { foreach (var _ in 0..); };

        action.Should().Throw<NotSupportedException>().WithMessage("The range end must be provided.");
    }
}
