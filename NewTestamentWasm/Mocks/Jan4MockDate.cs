namespace NewTestamentWasm.Mocks;
public class Jan4MockDate : IDateOnlyPicker
{
    DateOnly IDateOnlyPicker.GetCurrentDate => new(2022, 1, 4);
}