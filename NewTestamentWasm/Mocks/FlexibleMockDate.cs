namespace NewTestamentWasm.Mocks;
public class FlexibleMockDate : IDateOnlyPicker
{
    DateOnly IDateOnlyPicker.GetCurrentDate => dd.DateToUse;
}
