using Microsoft.AspNetCore.Components;

namespace EduVentureMubarakWebApp.Components.Components.Accordion;

public partial class AccordionItem : ComponentBase
{
    private readonly string _id = Guid.NewGuid().ToString();
    private string? _parent;
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public string Title { get; set; } = "Accordion title";
    [Parameter] public bool IsCollapsed { get; set; } = true;
    [CascadingParameter] public bool IsStayOpen { get; set; }
    [CascadingParameter] public string? ParentId { get; set; }

    protected override void OnInitialized()
    {
        if (!IsStayOpen)
            _parent = $"#{ParentId}";
        base.OnInitialized();
    }

}