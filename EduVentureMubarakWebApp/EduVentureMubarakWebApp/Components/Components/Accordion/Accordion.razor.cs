using Microsoft.AspNetCore.Components;

namespace EduVentureMubarakWebApp.Components.Components.Accordion;


public partial class Accordion :ComponentBase
{
    private string ParentId { get; } = Guid.NewGuid().ToString();
    private string _flush="";
    [Parameter] public bool Flush { get; set; }
    [Parameter] public bool IsStayOpen { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }

    protected override void OnInitialized()
    {
        if (Flush)
            _flush = "accordion-flush";
        base.OnInitialized();
    }
}