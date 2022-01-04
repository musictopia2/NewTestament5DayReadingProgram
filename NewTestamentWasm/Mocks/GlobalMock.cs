namespace NewTestamentWasm.Mocks;
public static class GlobalMock
{
    public static DateOnly DateToUse { get; set; } = new (2022, 1, 8); //default to weekend
}