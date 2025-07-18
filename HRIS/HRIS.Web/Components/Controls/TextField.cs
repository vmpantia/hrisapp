using MudBlazor;

namespace HRIS.Web.Components.Controls;

public class TextField<T> : MudTextField<T>
{
    public TextField()
    {
        Variant = Variant.Outlined;
        Margin = Margin.Dense;
    }
}